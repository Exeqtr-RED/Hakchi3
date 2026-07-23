!include "LogicLib.nsh"
!include "Sections.nsh"

; Display Version
; Updated: path to .NET 8 build
!system '..\hakchi_gui\bin\Release\net8.0-windows\hakchi.exe --versionFormat "!define DisplayVersion {0}" --versionFile version.nsh'
!include ".\version.nsh"
!system 'del version.nsh'

; The name of the installer
Name "Hakchi3 ${DisplayVersion} (Web)"

; The icon of the installer
Icon "..\hakchi_gui\icon_app.ico"

; The file to write
OutFile "..\hakchi_gui\bin\hakchi3-${DisplayVersion}-webinstaller.exe"

; The default installation directory
InstallDir "$PROGRAMFILES\Hakchi3"

; Registry key to check for directory
InstallDirRegKey HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\Hakchi3" "InstallLocation"

; Request application privileges for Windows Vista
RequestExecutionLevel admin

; Show details
ShowInstDetails show

; Plugins
!addplugindir .\Plugins

; Installer compression
SetCompressor /FINAL /SOLID lzma

;--------------------------------

Var DownloadURL

; Pages

Page components
Page directory
Page instfiles

UninstPage uninstConfirm
UninstPage instfiles

;--------------------------------

; The stuff to install

SectionGroup /e "Hakchi3 ${DisplayVersion} (required)"
  Section "Release Build" section_release
  SectionEnd
  Section /o "Debug Build" section_debug
  SectionEnd
SectionGroupEnd

Section
  SetShellVarContext all
  SectionIn RO

  ; Set output path to the installation directory.
  SetOutPath $INSTDIR

  ; Create the installation directory.
  CreateDirectory "$INSTDIR"

  ; Download update.xml
  inetc::get $DownloadURL "update.xml"
  Pop $0
  StrCmp $0 "OK" ParseXML InstallError

  ; Parse the xml
  ParseXML:
  nsisXML::create
  nsisXML::load "update.xml"
  Delete "update.xml"
  nsisXML::select '/item/url'
  IntCmp $2 0 InstallError
  nsisXML::getText

  ; Download the release package
  inetc::get "$3" "hakchi3.zip"
  Pop $0
  StrCmp $0 "OK" ExtractZip InstallError

  ExtractZip:
  ZipDLL::extractall "hakchi3.zip" "$INSTDIR"
  Delete "hakchi3.zip"

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

  Goto InstallEnd

  InstallError:
    Delete "update.xml"
    Delete "hakchi3.zip"
    RMDir "$INSTDIR"
    Abort

  InstallEnd:
  AccessControl::GrantOnFile "$INSTDIR\" "(BU)" "GenericRead + GenericWrite"

SectionEnd

Section "Start Menu Shortcuts"
  SetShellVarContext all
  CreateDirectory "$SMPROGRAMS\Hakchi3"
  CreateShortcut "$SMPROGRAMS\Hakchi3\Hakchi3.lnk" "$INSTDIR\hakchi.exe" "/nonportable" "$INSTDIR\hakchi.exe" 0
  CreateShortcut "$SMPROGRAMS\Hakchi3\Uninstall.lnk" "$INSTDIR\uninstall.exe" "" "$INSTDIR\uninstall.exe" 0
SectionEnd

Section "Desktop Shortcut"
  SetShellVarContext all
  CreateShortcut "$DESKTOP\Hakchi3.lnk" "$INSTDIR\hakchi.exe" "/nonportable" "$INSTDIR\hakchi.exe" 0
SectionEnd

;--------------------------------

; Uninstaller

Section "Uninstall"
  SetShellVarContext all

  ; Remove registry keys
  DeleteRegKey HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\Hakchi3"

  ; Remove files and directories used
  Delete "$DESKTOP\Hakchi3.lnk"
  RMDir /r "$SMPROGRAMS\Hakchi3"
  RMDir "$SMPROGRAMS\Hakchi3"
  RMDir /r "$INSTDIR"

SectionEnd

Function .onInit
  StrCpy $DownloadURL "https://exeqtr-red.github.io/Hakchi3/updates/update-release.xml"
  StrCpy $1 ${section_release}
  StrCpy $2 ${section_debug}

FunctionEnd

Function .onSelChange
  !insertmacro StartRadioButtons $1
    !insertmacro RadioButton ${section_release}
    !insertmacro RadioButton ${section_debug}
  !insertmacro EndRadioButtons

  ${If} ${SectionIsSelected} ${section_release}
    StrCpy $DownloadURL "https://exeqtr-red.github.io/Hakchi3/updates/update-release.xml"
  ${EndIf}
  ${If} ${SectionIsSelected} ${section_debug}
    StrCpy $DownloadURL "https://exeqtr-red.github.io/Hakchi3/updates/update-debug.xml"
  ${EndIf}

FunctionEnd
