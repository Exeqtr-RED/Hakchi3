# 🎮 Hakchi3

![License](https://img.shields.io/badge/license-GPL--3.0-blue.svg)
![Version](https://img.shields.io/badge/version-v0.3.5--beta-green.svg)
![Platform](https://img.shields.io/badge/platform-Windows-lightgrey.svg)
![.NET](https://img.shields.io/badge/.NET-8.0-512BD4.svg)
![Language](https://img.shields.io/badge/language-C%23%2012-purple.svg)
![Status](https://img.shields.io/badge/status-Active%20Beta-success.svg)
![Branch](https://img.shields.io/badge/branch-significant--changes-orange.svg)

> **Форк [Hakchi2-CE](https://github.com/TeamShinkansen/Hakchi2-CE) (Community Edition)**, мигрированный на .NET 8 с полной русификацией интерфейса, оптимизациями кода и набором исправлений ошибок оригинала.

---

## 📖 О проекте

**Hakchi3** — это неофициальная модификация утилиты **Hakchi2-CE** от [TeamShinkansen](https://github.com/TeamShinkansen), предназначенной для модификации и расширения возможностей ретро-консолей:

- 🎮 **NES Classic Edition** / **Famicom Classic Mini**
- 🎮 **SNES Classic Edition** / **Super Famicom Classic Mini**
- 🎮 **Sega Genesis Mini** / **Mega Drive Mini**

Этот форк базируется на версии v3.9.3 оригинального Hakchi2-CE и расширяет его: мигрирует кодовую базу на современный .NET 8, исправляет накопившиеся ошибки (включая редкие краши при закрытии диалогов и гонки в потоковом Tasker), добавляет новую тему оформления и кросс-платформенную сборку.

> ⚠️ **Это не официальный релиз** от TeamShinkansen. Все права на оригинальный код принадлежат их авторам ([ClusterM](https://github.com/ClusterM), [TeamShinkansen](https://github.com/TeamShinkansen)). Форк распространяется под той же лицензией GPL-3.0.

---

## 🌟 Ключевые особенности форка

### ⚙️ Модернизация платформы
- **🚀 Переход на .NET 8.0** — все проекты (включая `FelLib`, `Scrapers`, `SpineGen.Test`) мигрированы с .NET Framework / .NET Standard 2.0 на `net8.0` / `net8.0-windows`
- **📦 Обновление NuGet-пакетов** — `Newtonsoft.Json` 13.0.3, `SSH.NET` 2025.1.0, `SharpCompress` 0.48.0, `Markdig` 1.3.2 и др.
- **🔧 Замена устаревших API** — `WebRequest`/`HttpWebRequest` заменены на `HttpClient` (фикс `SYSLIB0014`)
- **🛡️ Исправление предупреждений компилятора** — все `CS####` (CS0162, CS0168, CS0169, CS0414, CS0472, CS8073, CS8981) и анализаторов (`CA2014`, `CA2021`) устранены; сборка проходит с **0 warnings, 0 errors**

### 🎨 Пользовательский интерфейс
- **🇷🇺 Полная русификация** — все элементы управления, меню, сообщения и диалоги переведены на русский язык
- **💧 IKEA-тема (Акварель)** — светлая тема с голубым акцентом `#4A90D9`, применяемая ко всем формам через `IKEATheme.Apply()`. Прогресс-бары в диалогах задач (`TaskerForm`, `TaskerTransferForm`, `WaitingShellCycleForm`) используют ту же палитру:
  - Фон: `RGB(230, 235, 240)` — `IKEATheme.Colors.ProgressTrack`
  - Заливка: `RGB(74, 144, 217)` — `IKEATheme.Colors.ProgressFill`
  - Leading edge: `RGB(100, 170, 240)` — `IKEATheme.Colors.AccentBlueHover`
  - Рамка: `RGB(200, 210, 220)` — `IKEATheme.Colors.Border`, Flat стиль

### 🐛 Исправления ошибок оригинала
- **🔧 `NullReferenceException` в `Tasker.startThread()`** — добавлены null-проверки для `_cts` и `tasks`; теперь закрытие формы во время выполнения задачи не крашит приложение
- **🔧 `UnauthorizedAccessException` в `TaskerForm.Show()/Close()`** — методы больше не кидают исключения при повторном вызове (например, когда форма уже скрыта); возвращают `this` молча
- **🔧 `hakchi.hmod not found in basehmods.tar`** — ce-data PreBuild теперь скачивает `hakchi.hmod` с GitHub через `curl`, если он отсутствует локально
- **🔧 CI-сборка на GitHub Actions** — PreBuild/PostBuild цели переписаны на нативные MSBuild-таски (`MakeDir`, `WriteLinesToFile`, `Copy`) вместо shell-out'а к `tools/busybox.exe`; теперь собирается и на Windows, и на Linux/macOS

### 📋 Сохранённый функционал оригинала
- ✅ Добавление дополнительных игр и контента на консоль
- ✅ Поддержка модулей (hmod) из репозиториев (KMFD mod hub, и др.)
- ✅ Запуск эмуляторов других систем (MAME, Game Boy Advance, NES, SNES, Genesis и др.)
- ✅ Настройка фильтров, шейдеров и улучшений изображения
- ✅ Backup/restore оригинального ядра консоли
- ✅ Поддержка drag-and-drop для добавления ROM-файлов

---

## 📋 Содержание

- [📺 Поддерживаемые устройства](#-поддерживаемые-устройства)
- [📥 Установка (готовый билд)](#-установка-готовый-билд)
- [🏗️ Сборка из исходников](#️-сборка-из-исходников)
- [⚙️ Технические детали и архитектура](#️-технические-детали-и-архитектура)
- [🧪 Тестирование](#-тестирование)
- [🤝 Вклад в развитие](#-вклад-в-развитие)
- [📜 Лицензия](#-лицензия)
- [🙏 Благодарности](#-благодарности)
- [🐞 TODO и известные проблемы](#-todo-и-известные-проблемы)

---

## 📺 Поддерживаемые устройства

| Консоль | Регион | Статус |
| :--- | :--- | :--- |
| **NES Classic Edition** | 🇺🇸 / 🇯🇵 | ✅ Полная |
| **Famicom Classic Edition** | 🇯🇵 | ✅ Полная |
| **SNES Classic Edition** | 🇺🇸 / 🇪🇺 | ✅ Полная |
| **Super Famicom Classic Edition** | 🇯🇵 | ✅ Полная |
| **Sega Genesis Mini** | 🇺🇸 | ✅ Полная |
| **Mega Drive Mini** | 🇪🇺 / 🇯🇵 | ✅ Полная |

**Требования к хосту:** Windows 10 1803+ / Windows 11 (64-бит), .NET 8 Desktop Runtime, USB-порт (для FEL-режима) или сеть (для clovershell/SSH).

---

## 📥 Установка (готовый билд)

### Способ 1 — Portable ZIP (рекомендуется)

1. Перейдите на страницу [**Releases**](https://github.com/Exeqtr-RED/Hakchi3/releases)
2. Скачайте `hakchi3-<version>-portable.zip` с последнего релиза
3. Распакуйте в любую папку (например, `C:\Hakchi3\`)
4. Запустите `hakchi.exe`

### Способ 2 — NSIS Installer

1. Скачайте `hakchi3-<version>-installer.exe` с [Releases](https://github.com/Exeqtr-RED/Hakchi3/releases)
2. Запустите installer от имени администратора
3. Следуйте указаниям мастера установки
4. Ярлык появится в меню «Пуск» и на рабочем столе

### Установка драйвера (для FEL-режима)

При первом подключении консоли в FEL-режиме (когда кабель вставлен и зажата кнопка Reset) Windows попросит драйвер. Установите `driver\classic_driver.exe` из папки Hakchi3 — это драйвер на базе libwdi/Zadig.

> ⚠️ **Важно:** Установка драйвера требует прав администратора. Если Windows заблокирует установку, отключите проверку подписи драйверов или используйте утилиту [Zadig](https://zadig.akeo.ie/) (gpzadig.exe также включён в `tools\`).

---

## 🏗️ Сборка из исходников

### Требования

| Компонент | Версия | Где взять |
| :--- | :--- | :--- |
| **.NET SDK** | 8.0.x | https://dotnet.microsoft.com/download/dotnet/8.0 |
| **Visual Studio 2022** | 17.8+ (опционально) | https://visualstudio.microsoft.com/ |
| **NSIS** | 3.x (для installer) | https://nsis.sourceforge.io/ |
| **Git** | любой | https://git-scm.com/ |
| **curl** | любой (в Windows 10 1803+ уже установлен) | https://curl.se/ |
| **tar** | любой (в Windows 10 1803+ уже установлен) | — |

Дополнительно для Visual Studio: workload **«.NET desktop development»** (включает Windows Forms).

### Быстрая сборка (командная строка)

```powershell
# 1. Клонировать репозиторий
git clone -b significant-changes https://github.com/Exeqtr-RED/Hakchi3.git
cd Hakchi3

# 2. Восстановить NuGet-пакеты
dotnet restore hakchi_gui.sln

# 3. Собрать Debug (для разработки)
dotnet build hakchi_gui.sln -c Debug

# ИЛИ собрать Release (для распространения)
dotnet build hakchi_gui.sln -c Release

# 4. Готовый hakchi.exe будет в:
#    hakchi_gui\bin\Release\net8.0-windows\hakchi.exe
```

### Сборка в Visual Studio 2022

1. Откройте `hakchi_gui.sln`
2. Выберите конфигурацию `Release` и платформу `Any CPU`
3. Нажмите `Ctrl+Shift+B` (Build Solution)
4. Результат — `hakchi_gui\bin\Release\net8.0-windows\hakchi.exe`

### Сборка через GitHub Actions (автоматическая)

Проект настроен на автоматическую сборку при пуше тега или в ветку `main`. Workflow находится в `.github/workflows/dotnet-desktop.yml`. После успешной сборки:

- Создаётся **portable ZIP** (`hakchi3-<version>-portable.zip`)
- Создаётся **NSIS installer** (`hakchi3-<version>-installer.exe`)
- При пуше тега — автоматически создаётся [GitHub Release](https://github.com/Exeqtr-RED/Hakchi3/releases) с обоими артефактами

Чтобы запустить сборку вручную: **Actions** → **Build and Release .NET Desktop App** → **Run workflow**.

### Конфигурации сборки

| Конфигурация | Назначение | Что включено |
| :--- | :--- | :--- |
| `Debug` | Разработка | Полные отладочные символы, проверки `#if DEBUG` |
| `Release` | Распространение | Оптимизация, обрезанные pdb |
| `Dumper` | Только dumping | Урезанный билд для создания дампов NAND — без hmod, без UI расширений |

### Что собирается автоматически во время билда

При сборке `hakchi_gui.sln` автоматически:

1. **`ce-data` PreBuild** скачивает `hakchi.hmod` с [TeamShinkansen/Hakchi2-CE releases](https://github.com/TeamShinkansen/Hakchi2-CE/releases) (через `curl`)
2. Собирает `GeneratedData/basehmods.tar` — архив всех `*.hmod` файлов из `hakchi_gui/mods/hmods/` (включая `hakchi.hmod`)
3. Собирает `GeneratedData/data/{licenses,libretro_cores,desktop_entries,original_art}.tar` из соответствующих папок `hakchi_gui/data/`
4. **`hakchi_gui` PreBuild** генерирует метаданные git:
   - `hakchi_gui/commit.txt` — короткий хэш коммита (`git rev-parse --short HEAD` + `-dirty` если есть изменения)
   - `hakchi_gui/tag.txt` — тег, указывающий на HEAD (`git describe --tags --exact-match`), или пустой
   - `hakchi_gui/git-commits-since-last-tag.txt` — список коммитов с последнего тега
   - `hakchi_gui/ApiKeys/TheGamesDB.txt` — пустой файл (для разработчика: можно вставить свой API-ключ TheGamesDB)
5. **`hakchi_gui` PostBuild** копирует `GeneratedData/` в выходную директорию (`bin/Release/net8.0-windows/`)

> 💡 **Офлайн-сборка:** если у вас нет интернета, `hakchi.hmod` не скачается — `basehmods.tar` будет без него. Положите файл вручную в `hakchi_gui/mods/hmods/hakchi.hmod` перед сборкой. Скачать можно с [TeamShinkansen/Hakchi2-CE releases → supplemental](https://github.com/TeamShinkansen/Hakchi2-CE/releases/tag/supplemental).

---

## ⚙️ Технические детали и архитектура

### Структура решения `hakchi_gui.sln`

```
Hakchi3/
├── hakchi_gui/                    # Основное приложение (WinForms, net8.0-windows)
│   ├── Properties/Resources.resx  # Строки локализации (ru, en, fr, de, it, ko, ...)
│   ├── Tasks/                     # Tasker framework + задачи (sync, dump, memboot, ...)
│   ├── Hmod/                      # Работа с .hmod пакетами
│   ├── Apps/                      # NesApplication, DesktopFile, GameGenieCode, ...
│   ├── ModHub/                    # ModHub UI (репозитории KMFD и др.)
│   ├── IKEATheme.cs               # Применение светлой темы ко всем формам
│   ├── hakchi.cs                  # Статический класс hakchi (Shell, DetectedConsoleType, ...)
│   ├── MainForm.cs                # Главная форма
│   └── AboutBox.cs                # Окно "О программе"
│
├── Scrapers/                      # Библиотека скрейперов TheGamesDB (net8.0)
├── Libraries/
│   ├── FelLib/                    # FEL-режим (USB, net8.0)
│   ├── ProgressODoom/             # Кастомные прогресс-бары (net8.0-windows)
│   ├── SpineGen/                  # Генерация spine-обложек
│   ├── tiny7z/                    # 7-zip компрессия
│   ├── CueSharp/                  # CUE-парсер
│   └── LibUsbDotNet/              # USB-драйвер (third-party, не модифицируется)
│
├── ce-data/                       # PreBuild-проект: собирает tar-архивы данных
├── Zipper/                        # Утилита для создания ZIP-архивов
├── NSI/nsi-helper/                # Утилита для генерации NSIS-скриптов
├── driver/                        # Windows-драйвер для FEL-режима
├── tools/                         # busybox.exe, wget.exe, puttytel.exe, mksquashfs
└── GeneratedData/                 # (создаётся при сборке) tar-архивы для hakchi.exe
```

### ProjectReference-граф

```
hakchi_gui (WinExe)
├── ce-data (library, build-order trigger)
├── CueSharp
├── FelLib
├── ProgressODoom
├── SpineGen + SpineGen.Drawing.System.Drawing + SpineGen.JSON
├── tiny7z
└── Scrapers
```

### Целевые фреймворки

| Проект | Target | Почему |
| :--- | :--- | :--- |
| `hakchi_gui` | `net8.0-windows` | WinForms, System.Drawing |
| `ProgressODoom` | `net8.0-windows` | WinForms-компоненты (designer) |
| `CueSharp` | `net8.0-windows` | Совместимость с WinForms-проектами |
| `SpineGen.*` | `net8.0-windows` | System.Drawing.Common |
| `Scrapers` | `net8.0` | Чисто managed, без Windows-зависимостей |
| `FelLib` | `net8.0` | Чисто managed (LibUsbDotNet 2.2.75 работает через netstandard) |
| `ce-data` | `net8.0-windows` | PreBuild-цель использует `tar` (доступен на Win10+) |
| `Zipper`, `nsi-helper` | `net8.0` | CLI-утилиты |

### Локализация

Поддерживаемые языки (в порядке полноты перевода):

| Язык | Код культуры | Файлы `.resx` |
| :--- | :--- | :--- |
| 🇷🇺 Русский (основной) | `ru` | `*.ru.resx` |
| 🇬🇧 Английский (fallback) | default | `*.resx` |
| 🇫🇷 Французский | `fr-FR` | `*.fr-FR.resx` |
| 🇩🇪 Немецкий | `de-DE` | `*.de-DE.resx` |
| 🇮🇹 Итальянский | `it` | `*.it.resx` |
| 🇰🇷 Корейский | `ko` | `*.ko.resx` |
| 🇧🇷 Португальский | `pt-BR` | `*.pt-BR.resx` |
| 🇪🇸 Испанский | `es` | `*.es.resx` |
| 🇸🇪 Шведский | `sv` | `*.sv.resx` |
| 🇸🇦 Арабский | `ar-SA` | `*.ar-SA.resx` |

Язык интерфейса выбирается автоматически по культуре ОС, либо вручную через `Настройки → Language`.

### Цветовая палитра IKEATheme

Вся тема приложения управляется из одного места — `hakchi_gui/IKEATheme.cs`. Чтобы поменять цвета, отредактируйте класс `IKEATheme.Colors` и пересоберите:

```csharp
public static class Colors {
    public static readonly Color FormBg        = Color.FromArgb(245, 246, 248);  // фон форм
    public static readonly Color ControlBg     = Color.White;                     // фон контролов
    public static readonly Color AccentBlue    = Color.FromArgb(74, 144, 217);   // акцент (кнопки, прогресс)
    public static readonly Color AccentBlueHover = Color.FromArgb(100, 170, 240);
    public static readonly Color ProgressFill  = Color.FromArgb(74, 144, 217);   // заливка прогресс-бара
    public static readonly Color ProgressTrack = Color.FromArgb(230, 235, 240);  // фон прогресс-бара
    public static readonly Color Border        = Color.FromArgb(200, 210, 220);  // рамки
    // ...
}
```

---

## 🧪 Тестирование

Этот раздел описывает, **что и как нужно проверить** после внесения изменений в код, чтобы убедиться, что форк остаётся стабильным. Тестирование разделено на 3 уровня: Smoke-тесты (быстрые), Функциональные (с консолью) и Регрессионные (после правок кода).

### 🔧 Предварительные условия

Для полного тестирования потребуется:
- ✅ Рабочий билд `hakchi.exe` (Debug или Release)
- ✅ Подключённая консоль (NES/SNES Classic или Sega Genesis Mini) — для тестов с устройством
- ✅ USB-кабель (тип A — micro-USB) — для FEL-режима
- ✅ ROM-файлы для тестов (например, `Super Mario World.smc`, `Sonic.md`)
- ✅ Опционально: API-ключ TheGamesDB (для тестов скрейпера обложек)

### Уровень 1 — Smoke-тесты (без консоли, ~10 минут)

Эти тесты проверяют, что приложение запускается и основные UI-функции работают. Выполняются на каждой сборке.

| # | Что проверить | Ожидаемый результат | Как проверить |
| :--- | :--- | :--- | :--- |
| 1.1 | **Запуск приложения** | `hakchi.exe` запускается без краша за < 5 сек | Двойной клик по `hakchi.exe`. Проверить окно `MainForm` появилось |
| 1.2 | **Заголовок окна** | `Hakchi3` + версия + git-коммит | Проверить строку заголовка: должна содержать `v0.3.5` и хэш |
| 1.3 | **AboutBox** | Credits отображаются **с переносами строк** (не одной строкой) | Меню `Help → About`. Проверить, что блок «Coders/Translators/Special thanks» разбит на строки |
| 1.4 | **Кнопка "Commits Since Last Tag"** | В AboutBox видна кнопка (если HEAD не на теге). При клике открывает TextInfo со списком коммитов | Кликнуть по кнопке. Проверить, что в списке **нет** строк `fatal:` или `invalid object name` |
| 1.5 | **Добавление ROM через drag-and-drop** | ROM появляется в списке игр | Перетащить `.smc` файл на форму. Проверить, что игра добавлена |
| 1.6 | **Смена языка** | Интерфейс переключается без перезапуска | `Settings → Language → English`, нажать OK. Проверить, что тексты сменились |
| 1.7 | **Прогресс-бар (визуально)** | Прогресс-бар **IKEA-стиль**: голубая заливка `#4A90D9` на светло-сером фоне `#E6EBF0`, серая рамка | Запустить любую задачу с прогрессом (например, `Add Games` → выбрать несколько ROM → OK). Проверить цвета в `TaskerForm` |
| 1.8 | **Закрытие формы во время задачи** | Приложение **не крашится** | Запустить длинную задачу (sync 50+ ROM), закрыть форму крестиком во время выполнения. Проверить, что приложение продолжает работать |
| 1.9 | **Проверка `basehmods.tar`** | Архив содержит `./hakchi.hmod` | В PowerShell: `tar -tf hakchi_gui\bin\Debug\net8.0-windows\basehmods.tar \| findstr hakchi.hmod` — должна вывести `./hakchi.hmod` |
| 1.10 | **Проверка метаданных git** | `commit.txt` содержит **одну** строку (хэш коммита), `tag.txt` пустой или с тегом, `git-commits-since-last-tag.txt` — список коммитов **без** `fatal:` | Открыть файлы `hakchi_gui\commit.txt`, `tag.txt`, `git-commits-since-last-tag.txt` в блокноте |

### Уровень 2 — Функциональные тесты с консолью (~30 минут)

Эти тесты требуют физически подключённой консоли. Выполняются перед релизом.

#### 2.1 Подключение и определение консоли

| # | Действие | Ожидаемый результат |
| :--- | :--- | :--- |
| 2.1.1 | Подключить консоль USB-кабелем к ПК, не включать | В статус-баре Hakchi3 появляется «Online» |
| 2.1.2 | Включить консоль в FEL-режиме (зажать Reset, вставить кабель) | Hakchi3 определяет консоль, показывает тип (NES/SNES/Sega) |
| 2.1.3 | Меню `Settings → Console type` → выбрать правильный тип | Сохраняется, перезапуск не сбрасывает |

#### 2.2 Синхронизация игр

| # | Действие | Ожидаемый результат |
| :--- | :--- | :--- |
| 2.2.1 | Добавить 3-5 ROM через drag-and-drop | Игры появляются в списке |
| 2.2.2 | Выбрать все игры, нажать `Synchronize selected games with [console]` | Открывается `TaskerForm`, прогресс-бар заполняется, задача завершается `Success` |
| 2.2.3 | Проверить на консоли | Все добавленные игры появляются в меню консоли, запускаются |
| 2.2.4 | Отключить консоль от ПК, перезагрузить | Игры остаются на консоли |

#### 2.3 Установка модулей (hmod)

| # | Действие | Ожидаемый результат |
| :--- | :--- | :--- |
| 2.3.1 | `Modules → Mod Hub` → выбрать модуль (например, RetroArch) | Модуль скачивается из репозитория |
| 2.3.2 | Установить модуль на консоль | `TaskerForm` показывает прогресс, завершается `Success` |
| 2.3.3 | Проверить на консоли | Модуль доступен через меню консоли |

#### 2.4 Backup и Restore

| # | Действие | Ожидаемый результат |
| :--- | :--- | :--- |
| 2.4.1 | `Kernel → Backup` | Создаётся backup оригинального ядра (файл `.tar` в папке пользователя) |
| 2.4.2 | `Kernel → Restore` (после модификаций) | Консоль возвращается к заводскому состоянию, все изменения отменены |

#### 2.5 FEL-режим (memboot)

| # | Действие | Ожидаемый результат |
| :--- | :--- | :--- |
| 2.5.1 | Включить консоль в FEL-режиме (Reset + USB) | Hakchi3 определяет FEL-устройство |
| 2.5.2 | `Kernel → Memboot` | Консоль загружается во временный модифицированный режим без записи во flash |
| 2.5.3 | Проверить, что изменения применены временно | После перезагрузки консоль возвращается к заводскому состоянию |

### Уровень 3 — Регрессионные тесты (после правок кода, ~15 минут)

Эти тесты выполняются **после внесения любых правок** в код, особенно в `Tasker.cs`, `TaskerForm.cs`, Designer-файлы и csproj-файлы.

| # | Что проверить | Почему важно | Как проверить |
| :--- | :--- | :--- | :--- |
| 3.1 | **Сборка без warnings** | Гарантия качества кода | `dotnet build hakchi_gui.sln -c Debug` → должно быть `0 Warning(s) 0 Error(s)` |
| 3.2 | **Release-сборка без warnings** | Гарантия для релиза | `dotnet build hakchi_gui.sln -c Release` → `0 Warning(s) 0 Error(s)` |
| 3.3 | **`hakchi.hmod` в `basehmods.tar`** | Без него приложение падает в рантайме с `InvalidOperationException` | `tar -tf hakchi_gui\bin\Release\net8.0-windows\basehmods.tar \| findstr hakchi.hmod` |
| 3.4 | **`licenses.tar` существует** | Resources.resx ссылается на него, без него сборка падает с `MSB3103` | `Test-Path hakchi_gui\bin\Release\net8.0-windows\data\licenses.tar` |
| 3.5 | **Нет ссылок на удалённые типы** | После рефакторинга могли остаться dangling refs | `Select-String -Path .\hakchi_gui\Tasks\*.Designer.cs -Pattern "Pixel\|RetroSegmented\|FruityLoops\|StyledBorder"` — должно вернуть пусто |
| 3.6 | **AboutBox показывает credits с переносами** | Регрессия CRLF-нормализации | Меню `Help → About` → проверить визуально |
| 3.7 | **Прогресс-бар IKEA-стиль** | Регрессия пейнтеров | Запустить любую задачу → проверить цвета (`#4A90D9` заливка) |
| 3.8 | **Закрытие формы во время задачи не крашит** | Регрессия `NullReferenceException` в `Tasker.startThread` | Запустить sync 50+ ROM, закрыть форму крестиком → приложение не падает |
| 3.9 | **Повторное `Show()/Close()` TaskerForm** | Регрессия `UnauthorizedAccessException` | Запустить задачу → закрыть → сразу запустить другую → не падает |
| 3.10 | **CI-сборка на GitHub Actions проходит** | Гарантия кросс-платформенной сборки | Запушить коммит → проверить, что Actions workflow завершился зелёным |

### 📊 Отчёт о тестировании

При обнаружении бага создайте [Issue](https://github.com/Exeqtr-RED/Hakchi3/issues/new?template=bug_report.md) со следующей информацией:

1. **Версия Hakchi3** (из `Help → About` или заголовка окна)
2. **Git-коммит** (виден в AboutBox или в `hakchi_gui/commit.txt`)
3. **Тип консоли** (NES/SNES/Sega, регион)
4. **ОС** (Windows 10/11, версия)
5. **Шаги для воспроизведения** (пошагово)
6. **Ожидаемое поведение**
7. **Фактическое поведение** (+ скриншот, если применимо)
8. **Лог отладки** — включите `hakchi-debug.bat`, повторите шаги, приложите `debug.log`

---

## 🤝 Вклад в развитие

### Как сообщить о баге

- [🐛 Bug Report](https://github.com/Exeqtr-RED/Hakchi3/issues/new?template=bug_report.md)
- [✨ Feature Request](https://github.com/Exeqtr-RED/Hakchi3/issues/new?template=feature_request.md)

### Как предложить правки

1. **Fork** репозитория
2. Создайте ветку: `git checkout -b feature/my-feature`
3. Закоммитьте изменения: `git commit -m 'Add my feature'`
4. Запушьте: `git push origin feature/my-feature`
5. Откройте **Pull Request** в ветку `significant-changes`

### Стиль кода

- C# 12, .NET 8
- Имена типов — PascalCase; методы — PascalCase; приватные поля — camelCase с `_` prefix
- Используйте `using var` вместо `using (...) { ... }` когда using-блок — последний в области видимости
- Избегайте `String.Format` — используйте `string.Format` (BCL alias)
- Все новые файлы `.cs` должны быть в **LF** (см. `.gitattributes`)
- Все новые файлы `.resx` — в **LF**
- Сборка должна проходить с **0 warnings, 0 errors**

### Сборка для тестирования PR

```powershell
git clone -b <your-branch> https://github.com/<your-username>/Hakchi3.git
cd Hakchi3
dotnet restore hakchi_gui.sln
dotnet build hakchi_gui.sln -c Debug
```

Затем выполните smoke-тесты из раздела [🧪 Тестирование](#-тестирование).

---

## 📜 Лицензия

Проект распространяется под лицензией **GNU General Public License v3.0** — см. [LICENSE](LICENSE).

Кратко:
- ✅ Можно использовать, модифицировать, распространять
- ✅ Можно делать коммерческое использование
- ❌ Должны сохранять лицензию GPL-3.0
- ❌ Должны открывать исходный код производных работ
- ❌ Без гарантий (as-is)

Оригинальный Hakchi2-CE от TeamShinkansen также под GPL-3.0 — см. [оригинальный LICENSE](https://github.com/TeamShinkansen/Hakchi2-CE/blob/master/LICENSE).

---

## 🙏 Благодарности

### Авторы оригинального Hakchi2-CE

- **[Alexey 'Cluster' Avdyukhin](https://github.com/ClusterM)** — автор оригинального hakchi
- **[princess_daphie](https://github.com/princess_daphie)** — соавтор Hakchi2-CE
- **[DanTheMan827](https://github.com/DanTheMan827)** — соавтор
- **[skogaby](https://github.com/skogaby)** — соавтор
- **[TeamShinkansen](https://github.com/TeamShinkansen)** — поддержкой Hakchi2-CE

### Переводчики

- 🇸🇦 Арабский: AluCarD
- 🇫🇷 Французский: princess_daphie, JumpmanFR
- 🇩🇪 Немецкий: Domi78
- 🇮🇹 Итальянский: Leonardo5681
- 🇰🇷 Корейский: DDinghoya
- 🇧🇷 Португальский: kONNEN
- 🇪🇸 Испанский (Лат. Америка): ReyVGM
- 🇸🇪 Шведский: yeager
- 🇷🇺 Русский: [Exeqtr-RED](https://github.com/Exeqtr-RED)

### Графика

- **[TheWez1981](https://www.facebook.com/TheWez81)** — Sega boxart и spine templates
- **HerbFargus** — фоны для папок (взятые из темы EmulationStation «TronkyFran»)
- **NeoRame** — графика

### Используемые библиотеки и инструменты

- **[libwdi](https://github.com/pbatard/libwdi) / [Zadig](https://zadig.akeo.ie/)** — Pete Batard/Akeo (USB-драйвер)
- **[WinUSBNet](https://github.com/madwizard-thomas/winusbnet)** — Thomas Bleeker
- **[bootgod's cartridge database](https://bootgod.dyndns.org:7777/)** — данные о картриджах NES
- **[SharpCompress](https://github.com/adamhathcock/sharpcompress)** — Adam Hathcock
- **[ProgressODoom](https://github.com/RalfBecher/Ressurect)** — BoneSoft (кастомные прогресс-бары)
- **[SSH.NET](https://github.com/sshnet/SSH.NET)** — Gert Driesen (clovershell-соединение)
- **[Newtonsoft.Json](https://www.newtonsoft.com/json)** — James Newton-King
- **[Markdig](https://github.com/xoofx/markdig)** — Alexandre Mutel (Markdown-рендеринг)
- **[LibUsbDotNet](https://github.com/LibUsbDotNet/LibUsbDotNet)** — Travis Robinson
- **[tiny7z](https://github.com/develop7/tiny7z)** — pdjtiny (LZMA-компрессия)
- **[CueSharp](https://github.com/nyash/CueSharp)** — CUE-парсер
- **[nQuant](https://github.com/mryanbrown/nQuant)** — Wu's color quantizer
- **[NSIS](https://nsis.sourceforge.io/)** — Nullsoft Scriptable Install System
- **[PuTTY](https://www.chiark.greenend.org.uk/~sgtatham/putty/)** — Simon Tatham (puttytel)

### Особая благодарность

- **madmonkey** и **pcm720** — за помощь во всём, что касается ядра и hakchi.hmod
- **Faustbear (u/faustbear)** — дополнительные графики для папок
- **Nhakin** — база данных Game Genie
- Все пользователи, сообщавшие о багах и предлагавших улучшения

---

## 🐞 TODO и известные проблемы

### TODO

- [ ] Обновить `hakchi.hmod` до последней версии (текущий — v1.0.4-126 от апреля 2020)
- [ ] Добавить unit-тесты для `Scrapers` (после удаления `Scrapers.Test` нужна замена)
- [ ] Локализация на китайский (упрощённый)
- [ ] Поддержка дополнительных эмуляторов в ModHub
- [ ] Тёмная тема (опционально, через `IKEATheme.Colors`)

### Известные проблемы

- **FEL-режим на Windows 11 22H2+** — иногда требует повторной установки драйвера через Zadig. Workaround: использовать `tools\gpzadig.exe`
- **Clovershell на macOS/Linux** — не работает (нужен Windows USB-драйвер). Workaround: использовать только FEL-режим
- **nQuant 1.0.3** — пакет собран под .NET Framework, но работает на .NET 8 (см. `NoWarn=NU1701` в csproj)
- **Large ROM (> 100 МБ)** — синхронизация может занимать до 10 минут; прогресс-бар может «зависать» на 99% во время финальной записи

### Связанные проекты

- **[Hakchi2-CE (оригинал)](https://github.com/TeamShinkansen/Hakchi2-CE)** — основа этого форка
- **[Hakchi2-CE Mod Hub](https://github.com/KMFDManic/NESC-SNESC-Modifications)** — репозиторий hmod-модулей
- **[TheGamesDB](https://thegamesdb.net/)** — источник метаданных и обложек
- **[libretro](https://www.libretro.com/)** — эмуляторы для RetroArch

---

## 📞 Контакты и ссылки

| Ресурс | Ссылка |
| :--- | :--- |
| 🏠 **Репозиторий** | https://github.com/Exeqtr-RED/Hakchi3 |
| 🌿 **Ветка разработки** | `significant-changes` |
| 📦 **Releases (билды)** | https://github.com/Exeqtr-RED/Hakchi3/releases |
| 🐛 **Сообщить о баге** | https://github.com/Exeqtr-RED/Hakchi3/issues/new?template=bug_report.md |
| ✨ **Предложить фичу** | https://github.com/Exeqtr-RED/Hakchi3/issues/new?template=feature_request.md |
| 💬 **Discussions** | https://github.com/Exeqtr-RED/Hakchi3/discussions |
| 📜 **Лицензия (GPL-3.0)** | [LICENSE](LICENSE) |
| 🔗 **Оригинал (Hakchi2-CE)** | https://github.com/TeamShinkansen/Hakchi2-CE |
| 🔗 **Mod Hub (KMFD)** | https://github.com/KMFDManic/NESC-SNESC-Modifications |
| 🔗 **TheGamesDB** | https://thegamesdb.net/ |

---

<div align="center">

**🎮 Hakchi3** — форк Hakchi2-CE на .NET 8 с русификацией и IKEA-темой.

Copyright © 2026 [Exeqtr-RED](https://github.com/Exeqtr-RED). Licensed under GPL-3.0.

</div>
