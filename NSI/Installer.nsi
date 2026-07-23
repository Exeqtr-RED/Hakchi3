!include "LogicLib.nsh"
!include "Sections.nsh"
!include "FileFunc.nsh"

; Display Version
; ИСПРАВЛЕНИЕ 1: Изменен путь с Debug\net48 на Release\net8.0-windows
!system '..\hakchi_gui\bin\Release\net8.0-windows\hakchi.exe --versionFormat "!define DisplayVersion {0}" --versionFile version.nsh'
!include ".\version.nsh"
!system 'del version.nsh'

; Create zip files
; ИСПРАВЛЕНИЕ 2: Изменен путь исходников. ИСПРАВЛЕНИЕ 3: Название архива hakchi3
!system '..\Zipper\bin\Release\net8.0-windows\Zipper.exe ..\hakchi_gui\bin\Release\net8.0-windows ..\hakchi_gui\bin\hakchi3-${DisplayVersion}-portable.zip'
; ВНИМАНИЕ: Если ты мигрировал утилиту Zipper на .NET 8, поменяй в строке выше net48 на net8.0-windows

; The icon of the installer
Icon "..\hakchi_gui\icon_app.ico"

; The file to write
; ИСПРАВЛЕНИЕ 4: Переименовано в hakchi3
OutFile "..\hakchi_gui\bin\hakchi3-${DisplayVersion}-installer.exe"

; The default installation directory
Var defaultInstDir
Var extractDir
Var mutex
Var launchExe
var launchArgs

; The name of the installer
; ИСПРАВЛЕНИЕ 5: Имя инсталлятора
Name "Hakchi3 ${DisplayVersion}"

; Registry key to check for directory
; ИСПРАВЛЕНИЕ 6: Сменил ветку реестра, чтобы Hakchi3 не конфликтовал с Hakchi2 CE на ПК пользователя
InstallDirRegKey HKLM "Software\Hakchi3" "Install_Dir"

; Request application privileges for Windows Vista
RequestExecutionLevel admin

; Show details
ShowInstDetails show

; Plugins
!addplugindir .\Plugins

; Installer compression
SetCompressor /FINAL /SOLID lzma

;--------------------------------

; Pages

Page components componentsPre
Page directory dirPre
Page instfiles

UninstPage uninstConfirm
UninstPage instfiles

;--------------------------------

; Sections
Section "" section_mutex
  ${GetOptions} $CMDLINE "-MUTEX=" $mutex
  ${If} $mutex != ""
    DetailPrint "Waiting for Hakchi3 to exit"
    mutexCheck:
    System::Call 'kernel32::OpenMutex(i 0x100000, b 0, t "$mutex") i .R0'
    IntCmp $R0 0 notRunning
      System::Call 'kernel32::CloseHandle(i $R0)'
      Sleep 1000
      Goto mutexCheck
    ${EndIf}
    notRunning:
SectionEnd

Section "Hakchi3 ${DisplayVersion} (required)" section_main
  SectionIn RO
  SetOutPath $INSTDIR
  ; ИСПРАВЛЕНИЕ 7: Берем файлы для инсталлятора из новой папки .NET 8
  File /r "..\hakchi_gui\bin\Release\net8.0-windows\*"
  AccessControl::GrantOnFile "$INSTDIR\" "(BU)" "GenericRead + GenericWrite"
SectionEnd

Section /o "Portable Install" section_portable
SectionEnd

Section "" section_install
  SetOutPath $INSTDIR

  ; Create nonportable.flag
  FileOpen $9 "nonportable.flag" w
  FileClose $9

  ; Write the installation path into the registry
  WriteRegStr HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\Hakchi3" "InstallLocation" "$INSTDIR"

  ; Write the uninstall keys for Windows
  WriteRegStr HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\Hakchi3" "DisplayName" "Hakchi3"
  WriteRegStr HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\Hakchi3" "DisplayVersion" "${DisplayVersion}"
  WriteRegStr HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\Hakchi3" "Publisher" "Exeqtr-RED"
  WriteRegStr HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\Hakchi3" "URLInfoAbout" "https://github.com/Exeqtr-RED/Hakchi3"
  WriteRegStr HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\Hakchi3" "HelpLink" "https://github.com/Exeqtr-RED/Hakchi3"
  WriteRegStr HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\Hakchi3" "URLUpdateInfo" "https://github.com/Exeqtr-RED/Hakchi3/releases"
  WriteRegStr HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\Hakchi3" "UninstallString" '"$INSTDIR\uninstall.exe"'
  WriteRegStr HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\Hakchi3" "DisplayIcon" '"$INSTDIR\hakchi.exe"'
  WriteRegDWORD HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\Hakchi3" "NoModify" 1
  WriteRegDWORD HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\Hakchi3" "NoRepair" 1
  WriteUninstaller "uninstall.exe"
SectionEnd

Section "Start Menu Shortcuts" section_startmenu
  SetShellVarContext all
  CreateDirectory "$SMPROGRAMS\Hakchi3"
  CreateShortcut "$SMPROGRAMS\Hakchi3\Hakchi3.lnk" "$INSTDIR\hakchi.exe" "/nonportable" "$INSTDIR\hakchi.exe" 0
  CreateShortcut "$SMPROGRAMS\Hakchi3\Hakchi3 (Debug).lnk" "$INSTDIR\hakchi.exe" "/nonportable /debug" "$INSTDIR\hakchi.exe" 0
  CreateShortcut "$SMPROGRAMS\Hakchi3\Uninstall.lnk" "$INSTDIR\uninstall.exe" "" "$INSTDIR\uninstall.exe" 0
SectionEnd

Section /o "Desktop Shortcut" section_desktop
  SetShellVarContext all
  CreateShortcut "$DESKTOP\Hakchi3.lnk" "$INSTDIR\hakchi.exe" "/nonportable" "$INSTDIR\hakchi.exe" 0
SectionEnd

Section "" section_launch
  ${GetOptions} $CMDLINE "-LAUNCH=" $launchExe
  ${GetOptions} $CMDLINE "-LAUNCH_ARGS=" $launchArgs

  ${If} $launchExe != ""
    SetAutoClose true
    SetOutPath "$INSTDIR"
    Exec '"$INSTDIR\$launchExe" $launchArgs'
  ${EndIf}
SectionEnd

Section "Uninstall"
  SetShellVarContext all

  ; Remove registry keys
  DeleteRegKey HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\Hakchi3"

  ; Remove files and directories used
  Delete "$DESKTOP\Hakchi3.lnk"
  RMDir /r "$SMPROGRAMS\Hakchi3"
  RMDir "$SMPROGRAMS\Hakchi3"

  ; ИСПРАВЛЕНИЕ 8: Подключаем файл, который реально генерирует vcxproj в релизе
  !include "release-uninstall.nsh"

  Delete "$INSTDIR\nonportable.flag"
  Delete "$INSTDIR\uninstall.exe"
  RMDir "$INSTDIR"
SectionEnd
;--------------------------------

Function .onInit
  StrCpy $defaultInstDir "$PROGRAMFILES\Hakchi3"
  StrCpy $InstDir $defaultInstDir
  IntOp $0 ${SF_SELECTED} | ${SF_RO}
  SectionSetFlags ${section_main} $0
FunctionEnd

Function .onSelChange
  ${If} ${SectionIsSelected} ${section_portable}
    ; ИСПРАВЛЕНИЕ 9: Обновлено название папки портативной версии
    StrCpy $InstDir "$EXEDIR\hakchi3-${DisplayVersion}"

    !insertmacro UnselectSection ${section_install}
    !insertmacro UnselectSection ${section_startmenu}
    !insertmacro UnselectSection ${section_desktop}
    SectionSetFlags ${section_startmenu} ${SF_RO}
    SectionSetFlags ${section_desktop} ${SF_RO}
  ${Else}
    StrCpy $InstDir $defaultInstDir

    SectionGetFlags ${section_startmenu} $0
    IntOp $0 $0 & ${SF_SELECTED}
    SectionSetFlags ${section_startmenu} $0

    SectionGetFlags ${section_desktop} $0
    IntOp $0 $0 & ${SF_SELECTED}
    SectionSetFlags ${section_desktop} $0

    !insertmacro SelectSection ${section_install}
  ${EndIf}

FunctionEnd

Function componentsPre
  ${GetOptions} $CMDLINE "-EXTRACT=" $extractDir
  ${If} $extractDir != ""
    StrCpy $InstDir "$extractDir"
    SectionSetFlags ${section_portable} ${SF_SELECTED}
    !insertmacro UnselectSection ${section_install}
    !insertmacro UnselectSection ${section_startmenu}
    !insertmacro UnselectSection ${section_desktop}
    SectionSetFlags ${section_startmenu} ${SF_RO}
    SectionSetFlags ${section_desktop} ${SF_RO}
    Abort
  ${EndIf}
FunctionEnd

Function dirPre
  ${If} $extractDir != ""
    Abort
  ${EndIf}
FunctionEnd