namespace com.clusterrr.hakchi_gui
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                StaticRef = null;
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            menuStrip = new System.Windows.Forms.MenuStrip();
            fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            addMoreGamesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            autodetectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            asIsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            addCustomAppToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            presetsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            addPresetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            deletePresetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            toolStripMenuItem13 = new System.Windows.Forms.ToolStripSeparator();
            exportGamesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            synchronizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            searchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            reloadGamesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            toolStripMenuItem12 = new System.Windows.Forms.ToolStripSeparator();
            resetOriginalGamesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            kernelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            flashCustomKernelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            resetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            uninstallToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            toolStripMenuItem11 = new System.Windows.Forms.ToolStripSeparator();
            flashUbootToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            normalModeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            sDModeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            advancedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            membootOriginalKernelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            membootCustomKernelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            membootRecoveryKernelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            toolStripMenuItem10 = new System.Windows.Forms.ToolStripSeparator();
            dumpOriginalKernellegacyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            toolStripMenuItem24 = new System.Windows.Forms.ToolStripSeparator();
            dumpTheWholeNANDToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            toolFlashTheWholeNANDStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            dumpNANDBToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            flashNANDBPartitionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            dumpNANDCPartitionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            flashNANDCPartitionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            formatNANDCToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            factoryResetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            modulesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            installModulesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            uninstallModulesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            generateModulesReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            modRepoStartSeparator = new System.Windows.Forms.ToolStripSeparator();
            modRepoEndSeparator = new System.Windows.Forms.ToolStripSeparator();
            manageModRepositoriesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            originalGamesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            positionAtTheTopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            positionAtTheBottomToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            positionSortedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            positionHiddenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            sortByToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            nameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            coreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            systemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            regionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            showGamesWithoutBoxArtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            languageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            segaUiThemeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            autoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            unitedStatesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            europeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            japanToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            sFROMToolToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            enableSFROMToolToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            usePCMPatchWhenAvailableToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            convertSNESROMSToSFROMToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            separateGamesStorageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            compressGamesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            compressBoxArtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            centerBoxArtThumbnailToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            disableHakchi2PopupsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            enableInformationScrapeOnImportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            toolStripMenuItem25 = new System.Windows.Forms.ToolStripSeparator();
            developerToolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            devForceSshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            uploadTotmpforTestingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            toolStripMenuItem23 = new System.Windows.Forms.ToolStripSeparator();
            forceNetworkMembootsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            forceClovershellMembootsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            downloadLatestHakchiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            separateGamesForMultibootToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            alwaysCopyOriginalGamesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            useLinkedSyncToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            toolStripMenuItem16 = new System.Windows.Forms.ToolStripSeparator();
            cloverconHackToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            resetUsingCombinationOfButtonsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            selectButtonCombinationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            enableAutofireToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            useXYOnClassicControllerAsAutofireABToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            upABStartOnSecondControllerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            globalCommandLineArgumentsexpertsOnluToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            kachikachiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            canoeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            retroarchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            epilepsyProtectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            toolStripMenuItem5 = new System.Windows.Forms.ToolStripSeparator();
            saveSettingsToNESMiniNowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            saveStateManagerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            importGamesFromMiniToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            takeScreenshotToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            saveDmesgOutputToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            toolStripMenuItem6 = new System.Windows.Forms.ToolStripSeparator();
            openFTPInExplorerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            openTelnetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            toolStripMenuItem8 = new System.Windows.Forms.ToolStripSeparator();
            bootImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            changeBootImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            disableBootImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            resetDefaultBootImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            rebootToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            switchRunningFirmwareToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            formatSDCardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            toolStripMenuItem18 = new System.Windows.Forms.ToolStripSeparator();
            prepareArtDirectoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            bluetoothToolStripMenuItem = new com.clusterrr.hakchi_gui.Wireless.Bluetooth.BluetoothMenuItem();
            helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            gitHubPageWithActualReleasesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            joinOurDiscordServerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            rRockinTheClassicsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            donateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            fAQToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            toolStripMenuItem22 = new System.Windows.Forms.ToolStripSeparator();
            technicalInformationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            messageOfTheDayToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            buttonAddGames = new System.Windows.Forms.Button();
            openFileDialogNes = new System.Windows.Forms.OpenFileDialog();
            contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(components);
            explorerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            addPrefixToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            removePrefixToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            toolStripMenuItem14 = new System.Windows.Forms.ToolStripSeparator();
            setRegionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            scrapeSelectedGamesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            scanForNewBoxArtForSelectedGamesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            downloadBoxArtForSelectedGamesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            deleteSelectedGamesBoxArtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            toolStripMenuItem15 = new System.Windows.Forms.ToolStripSeparator();
            archiveSelectedGamesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            compressSelectedGamesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            decompressSelectedGamesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            deleteSelectedGamesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            toolStripMenuItem17 = new System.Windows.Forms.ToolStripSeparator();
            sFROMToolToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            editROMHeaderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            toolStripMenuItem9 = new System.Windows.Forms.ToolStripSeparator();
            resetROMHeaderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            repairGamesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            toolStripMenuItem19 = new System.Windows.Forms.ToolStripSeparator();
            selectEmulationCoreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            openFileDialogImage = new System.Windows.Forms.OpenFileDialog();
            buttonStart = new System.Windows.Forms.Button();
            timerCalculateGames = new System.Windows.Forms.Timer(components);
            timerConnectionCheck = new System.Windows.Forms.Timer(components);
            saveDumpFileDialog = new System.Windows.Forms.SaveFileDialog();
            openDumpFileDialog = new System.Windows.Forms.OpenFileDialog();
            listViewGames = new System.Windows.Forms.ListView();
            gameName = new System.Windows.Forms.ColumnHeader();
            timerShowSelected = new System.Windows.Forms.Timer(components);
            buttonExport = new System.Windows.Forms.Button();
            labelID = new System.Windows.Forms.Label();
            textBoxName = new System.Windows.Forms.TextBox();
            labelPublisher = new System.Windows.Forms.Label();
            textBoxPublisher = new System.Windows.Forms.TextBox();
            labelCommandLine = new System.Windows.Forms.Label();
            textBoxArguments = new System.Windows.Forms.TextBox();
            pictureBoxArt = new System.Windows.Forms.PictureBox();
            buttonBrowseImage = new System.Windows.Forms.Button();
            buttonGoogle = new System.Windows.Forms.Button();
            labelMaxPlayers = new System.Windows.Forms.Label();
            labelGameGenie = new System.Windows.Forms.Label();
            textBoxGameGenie = new System.Windows.Forms.TextBox();
            labelReleaseDate = new System.Windows.Forms.Label();
            maskedTextBoxReleaseDate = new System.Windows.Forms.MaskedTextBox();
            buttonShowGameGenieDatabase = new System.Windows.Forms.Button();
            checkBoxCompressed = new System.Windows.Forms.CheckBox();
            labelSize = new System.Windows.Forms.Label();
            buttonDefaultCover = new System.Windows.Forms.Button();
            pictureBoxThumbnail = new System.Windows.Forms.PictureBox();
            labelSortName = new System.Windows.Forms.Label();
            textBoxSortName = new System.Windows.Forms.TextBox();
            labelSaveCount = new System.Windows.Forms.Label();
            numericUpDownSaveCount = new System.Windows.Forms.NumericUpDown();
            tableLayoutPanelGameInfo = new System.Windows.Forms.TableLayoutPanel();
            label10 = new System.Windows.Forms.Label();
            panel1 = new System.Windows.Forms.Panel();
            textBoxDescription = new System.Windows.Forms.TextBox();
            maxPlayersComboBox = new System.Windows.Forms.ComboBox();
            tableLayoutPanelGameID = new System.Windows.Forms.TableLayoutPanel();
            label9 = new System.Windows.Forms.Label();
            tableLayoutPanelGameGenie = new System.Windows.Forms.TableLayoutPanel();
            labelCompress = new System.Windows.Forms.Label();
            labelDescription = new System.Windows.Forms.Label();
            labelName = new System.Windows.Forms.Label();
            labelGenre = new System.Windows.Forms.Label();
            comboBoxGenre = new System.Windows.Forms.ComboBox();
            labelCountry = new System.Windows.Forms.Label();
            comboBoxCountry = new System.Windows.Forms.ComboBox();
            labelCopyright = new System.Windows.Forms.Label();
            textBoxCopyright = new System.Windows.Forms.TextBox();
            tableLayoutPanelArtButtons = new System.Windows.Forms.TableLayoutPanel();
            buttonSpine = new System.Windows.Forms.Button();
            pictureBoxM2Spine = new System.Windows.Forms.PictureBox();
            pictureBoxM2Front = new System.Windows.Forms.PictureBox();
            structureButton = new System.Windows.Forms.Button();
            foldersContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(components);
            disablePagefoldersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            customToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            automaticToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            automaticOriginalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            pagesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            pagesOriginalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            foldersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            foldersOriginalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            foldersSplitByFirstLetterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            foldersSplitByFirstLetterOriginalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
            maximumGamesPerFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            backFolderButtonPositionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            leftmostToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            rightmostToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            folderImagesSetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            toolStripMenuItem20 = new System.Windows.Forms.ToolStripSeparator();
            syncStructureForAllGamesCollectionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            gamesConsoleComboBox = new System.Windows.Forms.ComboBox();
            timerUpdate = new System.Windows.Forms.Timer(components);
            tableLayoutPanelMain = new System.Windows.Forms.TableLayoutPanel();
            groupBoxButtons = new System.Windows.Forms.GroupBox();
            groupBoxCurrentGamesCollection = new System.Windows.Forms.GroupBox();
            tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            groupBoxArtSega = new System.Windows.Forms.GroupBox();
            panel3 = new System.Windows.Forms.Panel();
            groupBoxArtNintendo = new System.Windows.Forms.GroupBox();
            panel2 = new System.Windows.Forms.Panel();
            groupBoxGameInfo = new System.Windows.Forms.GroupBox();
            tableLayoutPanelStatusBar = new System.Windows.Forms.TableLayoutPanel();
            toolStripStatusConnectionIcon = new System.Windows.Forms.PictureBox();
            tableLayoutPanelStatusBarInner = new System.Windows.Forms.TableLayoutPanel();
            toolStripStatusLabelShell = new System.Windows.Forms.Label();
            toolStripStatusLabelSelected = new System.Windows.Forms.Label();
            toolStripStatusLabelSize = new System.Windows.Forms.Label();
            toolStripProgressBar = new System.Windows.Forms.ProgressBar();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            progressBar1 = new System.Windows.Forms.ProgressBar();
            menuStrip.SuspendLayout();
            contextMenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxArt).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxThumbnail).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownSaveCount).BeginInit();
            tableLayoutPanelGameInfo.SuspendLayout();
            panel1.SuspendLayout();
            tableLayoutPanelGameID.SuspendLayout();
            tableLayoutPanelGameGenie.SuspendLayout();
            tableLayoutPanelArtButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxM2Spine).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxM2Front).BeginInit();
            foldersContextMenuStrip.SuspendLayout();
            tableLayoutPanelMain.SuspendLayout();
            groupBoxButtons.SuspendLayout();
            groupBoxCurrentGamesCollection.SuspendLayout();
            tableLayoutPanel3.SuspendLayout();
            groupBoxArtSega.SuspendLayout();
            panel3.SuspendLayout();
            groupBoxArtNintendo.SuspendLayout();
            panel2.SuspendLayout();
            groupBoxGameInfo.SuspendLayout();
            tableLayoutPanelStatusBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)toolStripStatusConnectionIcon).BeginInit();
            tableLayoutPanelStatusBarInner.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip
            // 
            menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { fileToolStripMenuItem, kernelToolStripMenuItem, modulesToolStripMenuItem, viewToolStripMenuItem, settingsToolStripMenuItem, toolsToolStripMenuItem, bluetoothToolStripMenuItem, helpToolStripMenuItem });
            resources.ApplyResources(menuStrip, "menuStrip");
            menuStrip.Name = "menuStrip";
            menuStrip.MenuActivate += MenuStrip_MenuActivate;
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { addMoreGamesToolStripMenuItem, addCustomAppToolStripMenuItem, presetsToolStripMenuItem, toolStripMenuItem13, exportGamesToolStripMenuItem, synchronizeToolStripMenuItem, searchToolStripMenuItem, reloadGamesToolStripMenuItem, toolStripMenuItem12, resetOriginalGamesToolStripMenuItem, toolStripMenuItem1, exitToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            resources.ApplyResources(fileToolStripMenuItem, "fileToolStripMenuItem");
            // 
            // addMoreGamesToolStripMenuItem
            // 
            addMoreGamesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { autodetectToolStripMenuItem, asIsToolStripMenuItem });
            addMoreGamesToolStripMenuItem.Name = "addMoreGamesToolStripMenuItem";
            resources.ApplyResources(addMoreGamesToolStripMenuItem, "addMoreGamesToolStripMenuItem");
            // 
            // autodetectToolStripMenuItem
            // 
            autodetectToolStripMenuItem.Name = "autodetectToolStripMenuItem";
            resources.ApplyResources(autodetectToolStripMenuItem, "autodetectToolStripMenuItem");
            autodetectToolStripMenuItem.Click += buttonAddGames_Click;
            // 
            // asIsToolStripMenuItem
            // 
            asIsToolStripMenuItem.Name = "asIsToolStripMenuItem";
            resources.ApplyResources(asIsToolStripMenuItem, "asIsToolStripMenuItem");
            asIsToolStripMenuItem.Click += asIsToolStripMenuItem_Click;
            // 
            // addCustomAppToolStripMenuItem
            // 
            addCustomAppToolStripMenuItem.Name = "addCustomAppToolStripMenuItem";
            resources.ApplyResources(addCustomAppToolStripMenuItem, "addCustomAppToolStripMenuItem");
            addCustomAppToolStripMenuItem.Click += addCustomAppToolStripMenuItem_Click;
            // 
            // presetsToolStripMenuItem
            // 
            presetsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { toolStripMenuItem2, addPresetToolStripMenuItem, deletePresetToolStripMenuItem });
            presetsToolStripMenuItem.Name = "presetsToolStripMenuItem";
            resources.ApplyResources(presetsToolStripMenuItem, "presetsToolStripMenuItem");
            // 
            // toolStripMenuItem2
            // 
            toolStripMenuItem2.Name = "toolStripMenuItem2";
            resources.ApplyResources(toolStripMenuItem2, "toolStripMenuItem2");
            // 
            // addPresetToolStripMenuItem
            // 
            addPresetToolStripMenuItem.Name = "addPresetToolStripMenuItem";
            resources.ApplyResources(addPresetToolStripMenuItem, "addPresetToolStripMenuItem");
            addPresetToolStripMenuItem.Click += AddPreset;
            // 
            // deletePresetToolStripMenuItem
            // 
            deletePresetToolStripMenuItem.Name = "deletePresetToolStripMenuItem";
            resources.ApplyResources(deletePresetToolStripMenuItem, "deletePresetToolStripMenuItem");
            // 
            // toolStripMenuItem13
            // 
            toolStripMenuItem13.Name = "toolStripMenuItem13";
            resources.ApplyResources(toolStripMenuItem13, "toolStripMenuItem13");
            // 
            // exportGamesToolStripMenuItem
            // 
            exportGamesToolStripMenuItem.Name = "exportGamesToolStripMenuItem";
            resources.ApplyResources(exportGamesToolStripMenuItem, "exportGamesToolStripMenuItem");
            exportGamesToolStripMenuItem.Click += buttonExport_Click;
            // 
            // synchronizeToolStripMenuItem
            // 
            synchronizeToolStripMenuItem.Name = "synchronizeToolStripMenuItem";
            resources.ApplyResources(synchronizeToolStripMenuItem, "synchronizeToolStripMenuItem");
            synchronizeToolStripMenuItem.Click += buttonStart_Click;
            // 
            // searchToolStripMenuItem
            // 
            searchToolStripMenuItem.Name = "searchToolStripMenuItem";
            resources.ApplyResources(searchToolStripMenuItem, "searchToolStripMenuItem");
            searchToolStripMenuItem.Click += searchToolStripMenuItem_Click;
            // 
            // reloadGamesToolStripMenuItem
            // 
            reloadGamesToolStripMenuItem.Name = "reloadGamesToolStripMenuItem";
            resources.ApplyResources(reloadGamesToolStripMenuItem, "reloadGamesToolStripMenuItem");
            reloadGamesToolStripMenuItem.Click += reloadGamesToolStripMenuItem_Click;
            // 
            // toolStripMenuItem12
            // 
            toolStripMenuItem12.Name = "toolStripMenuItem12";
            resources.ApplyResources(toolStripMenuItem12, "toolStripMenuItem12");
            // 
            // resetOriginalGamesToolStripMenuItem
            // 
            resetOriginalGamesToolStripMenuItem.Name = "resetOriginalGamesToolStripMenuItem";
            resources.ApplyResources(resetOriginalGamesToolStripMenuItem, "resetOriginalGamesToolStripMenuItem");
            resetOriginalGamesToolStripMenuItem.Click += resetOriginalGamesToolStripMenuItem_Click;
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            resources.ApplyResources(toolStripMenuItem1, "toolStripMenuItem1");
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            resources.ApplyResources(exitToolStripMenuItem, "exitToolStripMenuItem");
            exitToolStripMenuItem.Click += exitToolStripMenuItem_Click;
            // 
            // kernelToolStripMenuItem
            // 
            kernelToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { flashCustomKernelToolStripMenuItem, resetToolStripMenuItem, uninstallToolStripMenuItem, toolStripMenuItem11, flashUbootToolStripMenuItem, advancedToolStripMenuItem });
            kernelToolStripMenuItem.Name = "kernelToolStripMenuItem";
            resources.ApplyResources(kernelToolStripMenuItem, "kernelToolStripMenuItem");
            // 
            // flashCustomKernelToolStripMenuItem
            // 
            flashCustomKernelToolStripMenuItem.Name = "flashCustomKernelToolStripMenuItem";
            resources.ApplyResources(flashCustomKernelToolStripMenuItem, "flashCustomKernelToolStripMenuItem");
            flashCustomKernelToolStripMenuItem.Click += flashCustomKernelToolStripMenuItem_Click;
            // 
            // resetToolStripMenuItem
            // 
            resetToolStripMenuItem.Name = "resetToolStripMenuItem";
            resources.ApplyResources(resetToolStripMenuItem, "resetToolStripMenuItem");
            resetToolStripMenuItem.Click += resetToolStripMenuItem_Click;
            // 
            // uninstallToolStripMenuItem
            // 
            uninstallToolStripMenuItem.Name = "uninstallToolStripMenuItem";
            resources.ApplyResources(uninstallToolStripMenuItem, "uninstallToolStripMenuItem");
            uninstallToolStripMenuItem.Text = Properties.Resources.Uninstall;
            uninstallToolStripMenuItem.Click += uninstallToolStripMenuItem_Click;
            // 
            // toolStripMenuItem11
            // 
            toolStripMenuItem11.Name = "toolStripMenuItem11";
            resources.ApplyResources(toolStripMenuItem11, "toolStripMenuItem11");
            // 
            // flashUbootToolStripMenuItem
            // 
            flashUbootToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { normalModeToolStripMenuItem, sDModeToolStripMenuItem });
            flashUbootToolStripMenuItem.Name = "flashUbootToolStripMenuItem";
            resources.ApplyResources(flashUbootToolStripMenuItem, "flashUbootToolStripMenuItem");
            // 
            // normalModeToolStripMenuItem
            // 
            normalModeToolStripMenuItem.Name = "normalModeToolStripMenuItem";
            resources.ApplyResources(normalModeToolStripMenuItem, "normalModeToolStripMenuItem");
            normalModeToolStripMenuItem.Tag = Tasks.MembootTasks.MembootTaskType.FlashNormalUboot;
            normalModeToolStripMenuItem.Click += flashUbootToolStripMenuItem_Click;
            // 
            // sDModeToolStripMenuItem
            // 
            sDModeToolStripMenuItem.Name = "sDModeToolStripMenuItem";
            resources.ApplyResources(sDModeToolStripMenuItem, "sDModeToolStripMenuItem");
            sDModeToolStripMenuItem.Tag = Tasks.MembootTasks.MembootTaskType.FlashSDUboot;
            sDModeToolStripMenuItem.Click += flashUbootToolStripMenuItem_Click;
            // 
            // advancedToolStripMenuItem
            // 
            advancedToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { membootOriginalKernelToolStripMenuItem, membootCustomKernelToolStripMenuItem, membootRecoveryKernelToolStripMenuItem, toolStripMenuItem10, dumpOriginalKernellegacyToolStripMenuItem, toolStripMenuItem24, dumpTheWholeNANDToolStripMenuItem, toolFlashTheWholeNANDStripMenuItem, dumpNANDBToolStripMenuItem, flashNANDBPartitionToolStripMenuItem, dumpNANDCPartitionToolStripMenuItem, flashNANDCPartitionToolStripMenuItem, formatNANDCToolStripMenuItem, toolStripSeparator1, factoryResetToolStripMenuItem });
            advancedToolStripMenuItem.Name = "advancedToolStripMenuItem";
            resources.ApplyResources(advancedToolStripMenuItem, "advancedToolStripMenuItem");
            // 
            // membootOriginalKernelToolStripMenuItem
            // 
            membootOriginalKernelToolStripMenuItem.Name = "membootOriginalKernelToolStripMenuItem";
            resources.ApplyResources(membootOriginalKernelToolStripMenuItem, "membootOriginalKernelToolStripMenuItem");
            membootOriginalKernelToolStripMenuItem.Click += membootOriginalKernelToolStripMenuItem_Click;
            // 
            // membootCustomKernelToolStripMenuItem
            // 
            membootCustomKernelToolStripMenuItem.Name = "membootCustomKernelToolStripMenuItem";
            resources.ApplyResources(membootCustomKernelToolStripMenuItem, "membootCustomKernelToolStripMenuItem");
            membootCustomKernelToolStripMenuItem.Click += membootCustomKernelToolStripMenuItem_Click;
            // 
            // membootRecoveryKernelToolStripMenuItem
            // 
            membootRecoveryKernelToolStripMenuItem.Name = "membootRecoveryKernelToolStripMenuItem";
            resources.ApplyResources(membootRecoveryKernelToolStripMenuItem, "membootRecoveryKernelToolStripMenuItem");
            membootRecoveryKernelToolStripMenuItem.Click += membootRecoveryKernelToolStripMenuItem_Click;
            // 
            // toolStripMenuItem10
            // 
            toolStripMenuItem10.Name = "toolStripMenuItem10";
            resources.ApplyResources(toolStripMenuItem10, "toolStripMenuItem10");
            // 
            // dumpOriginalKernellegacyToolStripMenuItem
            // 
            dumpOriginalKernellegacyToolStripMenuItem.Name = "dumpOriginalKernellegacyToolStripMenuItem";
            resources.ApplyResources(dumpOriginalKernellegacyToolStripMenuItem, "dumpOriginalKernellegacyToolStripMenuItem");
            dumpOriginalKernellegacyToolStripMenuItem.Click += dumpOriginalKernellegacyToolStripMenuItem_Click;
            // 
            // toolStripMenuItem24
            // 
            toolStripMenuItem24.Name = "toolStripMenuItem24";
            resources.ApplyResources(toolStripMenuItem24, "toolStripMenuItem24");
            // 
            // dumpTheWholeNANDToolStripMenuItem
            // 
            dumpTheWholeNANDToolStripMenuItem.Name = "dumpTheWholeNANDToolStripMenuItem";
            resources.ApplyResources(dumpTheWholeNANDToolStripMenuItem, "dumpTheWholeNANDToolStripMenuItem");
            dumpTheWholeNANDToolStripMenuItem.Click += dumpTheWholeNANDToolStripMenuItem_Click;
            // 
            // toolFlashTheWholeNANDStripMenuItem
            // 
            toolFlashTheWholeNANDStripMenuItem.Name = "toolFlashTheWholeNANDStripMenuItem";
            resources.ApplyResources(toolFlashTheWholeNANDStripMenuItem, "toolFlashTheWholeNANDStripMenuItem");
            toolFlashTheWholeNANDStripMenuItem.Click += toolFlashTheWholeNANDStripMenuItem_Click;
            // 
            // dumpNANDBToolStripMenuItem
            // 
            dumpNANDBToolStripMenuItem.Name = "dumpNANDBToolStripMenuItem";
            resources.ApplyResources(dumpNANDBToolStripMenuItem, "dumpNANDBToolStripMenuItem");
            dumpNANDBToolStripMenuItem.Click += dumpNANDBToolStripMenuItem_Click;
            // 
            // flashNANDBPartitionToolStripMenuItem
            // 
            flashNANDBPartitionToolStripMenuItem.Name = "flashNANDBPartitionToolStripMenuItem";
            resources.ApplyResources(flashNANDBPartitionToolStripMenuItem, "flashNANDBPartitionToolStripMenuItem");
            flashNANDBPartitionToolStripMenuItem.Click += flashNANDBPartitionToolStripMenuItem_Click;
            // 
            // dumpNANDCPartitionToolStripMenuItem
            // 
            dumpNANDCPartitionToolStripMenuItem.Name = "dumpNANDCPartitionToolStripMenuItem";
            resources.ApplyResources(dumpNANDCPartitionToolStripMenuItem, "dumpNANDCPartitionToolStripMenuItem");
            dumpNANDCPartitionToolStripMenuItem.Click += dumpNANDCPartitionToolStripMenuItem_Click;
            // 
            // flashNANDCPartitionToolStripMenuItem
            // 
            flashNANDCPartitionToolStripMenuItem.Name = "flashNANDCPartitionToolStripMenuItem";
            resources.ApplyResources(flashNANDCPartitionToolStripMenuItem, "flashNANDCPartitionToolStripMenuItem");
            flashNANDCPartitionToolStripMenuItem.Click += flashNANDCPartitionToolStripMenuItem_Click;
            // 
            // formatNANDCToolStripMenuItem
            // 
            formatNANDCToolStripMenuItem.Name = "formatNANDCToolStripMenuItem";
            resources.ApplyResources(formatNANDCToolStripMenuItem, "formatNANDCToolStripMenuItem");
            formatNANDCToolStripMenuItem.Click += formatNANDCToolStripMenuItem_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            resources.ApplyResources(toolStripSeparator1, "toolStripSeparator1");
            // 
            // factoryResetToolStripMenuItem
            // 
            resources.ApplyResources(factoryResetToolStripMenuItem, "factoryResetToolStripMenuItem");
            factoryResetToolStripMenuItem.Name = "factoryResetToolStripMenuItem";
            factoryResetToolStripMenuItem.Text = Properties.Resources.FactoryReset;
            factoryResetToolStripMenuItem.Click += factoryResetToolStripMenuItem_Click;
            // 
            // modulesToolStripMenuItem
            // 
            modulesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { installModulesToolStripMenuItem, uninstallModulesToolStripMenuItem, generateModulesReportToolStripMenuItem, modRepoStartSeparator, modRepoEndSeparator, manageModRepositoriesToolStripMenuItem });
            modulesToolStripMenuItem.Name = "modulesToolStripMenuItem";
            resources.ApplyResources(modulesToolStripMenuItem, "modulesToolStripMenuItem");
            // 
            // installModulesToolStripMenuItem
            // 
            installModulesToolStripMenuItem.Name = "installModulesToolStripMenuItem";
            resources.ApplyResources(installModulesToolStripMenuItem, "installModulesToolStripMenuItem");
            installModulesToolStripMenuItem.Click += installModulesToolStripMenuItem_Click;
            // 
            // uninstallModulesToolStripMenuItem
            // 
            uninstallModulesToolStripMenuItem.Name = "uninstallModulesToolStripMenuItem";
            resources.ApplyResources(uninstallModulesToolStripMenuItem, "uninstallModulesToolStripMenuItem");
            uninstallModulesToolStripMenuItem.Click += uninstallModulesToolStripMenuItem_Click;
            // 
            // generateModulesReportToolStripMenuItem
            // 
            generateModulesReportToolStripMenuItem.Name = "generateModulesReportToolStripMenuItem";
            resources.ApplyResources(generateModulesReportToolStripMenuItem, "generateModulesReportToolStripMenuItem");
            generateModulesReportToolStripMenuItem.Click += generateModulesReportToolStripMenuItem_Click;
            // 
            // modRepoStartSeparator
            // 
            modRepoStartSeparator.Name = "modRepoStartSeparator";
            resources.ApplyResources(modRepoStartSeparator, "modRepoStartSeparator");
            // 
            // modRepoEndSeparator
            // 
            modRepoEndSeparator.Name = "modRepoEndSeparator";
            resources.ApplyResources(modRepoEndSeparator, "modRepoEndSeparator");
            // 
            // manageModRepositoriesToolStripMenuItem
            // 
            manageModRepositoriesToolStripMenuItem.Name = "manageModRepositoriesToolStripMenuItem";
            resources.ApplyResources(manageModRepositoriesToolStripMenuItem, "manageModRepositoriesToolStripMenuItem");
            manageModRepositoriesToolStripMenuItem.Click += manageModRepositoriesToolStripMenuItem_Click;
            // 
            // viewToolStripMenuItem
            // 
            viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { originalGamesToolStripMenuItem, sortByToolStripMenuItem, showGamesWithoutBoxArtToolStripMenuItem });
            viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            resources.ApplyResources(viewToolStripMenuItem, "viewToolStripMenuItem");
            // 
            // originalGamesToolStripMenuItem
            // 
            originalGamesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { positionAtTheTopToolStripMenuItem, positionAtTheBottomToolStripMenuItem, positionSortedToolStripMenuItem, positionHiddenToolStripMenuItem });
            originalGamesToolStripMenuItem.Name = "originalGamesToolStripMenuItem";
            resources.ApplyResources(originalGamesToolStripMenuItem, "originalGamesToolStripMenuItem");
            // 
            // positionAtTheTopToolStripMenuItem
            // 
            positionAtTheTopToolStripMenuItem.Name = "positionAtTheTopToolStripMenuItem";
            resources.ApplyResources(positionAtTheTopToolStripMenuItem, "positionAtTheTopToolStripMenuItem");
            positionAtTheTopToolStripMenuItem.Tag = "0";
            positionAtTheTopToolStripMenuItem.Click += originalGamesPositionToolStripMenuItem_Click;
            // 
            // positionAtTheBottomToolStripMenuItem
            // 
            positionAtTheBottomToolStripMenuItem.Name = "positionAtTheBottomToolStripMenuItem";
            resources.ApplyResources(positionAtTheBottomToolStripMenuItem, "positionAtTheBottomToolStripMenuItem");
            positionAtTheBottomToolStripMenuItem.Tag = "1";
            positionAtTheBottomToolStripMenuItem.Click += originalGamesPositionToolStripMenuItem_Click;
            // 
            // positionSortedToolStripMenuItem
            // 
            positionSortedToolStripMenuItem.Name = "positionSortedToolStripMenuItem";
            resources.ApplyResources(positionSortedToolStripMenuItem, "positionSortedToolStripMenuItem");
            positionSortedToolStripMenuItem.Tag = "2";
            positionSortedToolStripMenuItem.Click += originalGamesPositionToolStripMenuItem_Click;
            // 
            // positionHiddenToolStripMenuItem
            // 
            positionHiddenToolStripMenuItem.Name = "positionHiddenToolStripMenuItem";
            resources.ApplyResources(positionHiddenToolStripMenuItem, "positionHiddenToolStripMenuItem");
            positionHiddenToolStripMenuItem.Tag = "3";
            positionHiddenToolStripMenuItem.Click += originalGamesPositionToolStripMenuItem_Click;
            // 
            // sortByToolStripMenuItem
            // 
            sortByToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { nameToolStripMenuItem, coreToolStripMenuItem, systemToolStripMenuItem, regionToolStripMenuItem });
            sortByToolStripMenuItem.Name = "sortByToolStripMenuItem";
            resources.ApplyResources(sortByToolStripMenuItem, "sortByToolStripMenuItem");
            // 
            // nameToolStripMenuItem
            // 
            nameToolStripMenuItem.Name = "nameToolStripMenuItem";
            resources.ApplyResources(nameToolStripMenuItem, "nameToolStripMenuItem");
            nameToolStripMenuItem.Tag = "0";
            nameToolStripMenuItem.Click += sortByToolStripMenuItem_Click;
            // 
            // coreToolStripMenuItem
            // 
            coreToolStripMenuItem.Name = "coreToolStripMenuItem";
            resources.ApplyResources(coreToolStripMenuItem, "coreToolStripMenuItem");
            coreToolStripMenuItem.Tag = "1";
            coreToolStripMenuItem.Click += sortByToolStripMenuItem_Click;
            // 
            // systemToolStripMenuItem
            // 
            systemToolStripMenuItem.Name = "systemToolStripMenuItem";
            resources.ApplyResources(systemToolStripMenuItem, "systemToolStripMenuItem");
            systemToolStripMenuItem.Tag = "2";
            systemToolStripMenuItem.Click += sortByToolStripMenuItem_Click;
            // 
            // regionToolStripMenuItem
            // 
            regionToolStripMenuItem.Name = "regionToolStripMenuItem";
            resources.ApplyResources(regionToolStripMenuItem, "regionToolStripMenuItem");
            regionToolStripMenuItem.Tag = "3";
            regionToolStripMenuItem.Click += sortByToolStripMenuItem_Click;
            // 
            // showGamesWithoutBoxArtToolStripMenuItem
            // 
            showGamesWithoutBoxArtToolStripMenuItem.Checked = true;
            showGamesWithoutBoxArtToolStripMenuItem.CheckOnClick = true;
            showGamesWithoutBoxArtToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            showGamesWithoutBoxArtToolStripMenuItem.Name = "showGamesWithoutBoxArtToolStripMenuItem";
            resources.ApplyResources(showGamesWithoutBoxArtToolStripMenuItem, "showGamesWithoutBoxArtToolStripMenuItem");
            showGamesWithoutBoxArtToolStripMenuItem.Click += showGamesWithoutBoxArtToolStripMenuItem_Click;
            // 
            // settingsToolStripMenuItem
            // 
            settingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { languageToolStripMenuItem, segaUiThemeToolStripMenuItem, sFROMToolToolStripMenuItem, convertSNESROMSToSFROMToolStripMenuItem, separateGamesStorageToolStripMenuItem, compressGamesToolStripMenuItem, compressBoxArtToolStripMenuItem, centerBoxArtThumbnailToolStripMenuItem, disableHakchi2PopupsToolStripMenuItem, enableInformationScrapeOnImportToolStripMenuItem, toolStripMenuItem25, developerToolsToolStripMenuItem, separateGamesForMultibootToolStripMenuItem, alwaysCopyOriginalGamesToolStripMenuItem, useLinkedSyncToolStripMenuItem, toolStripMenuItem16, cloverconHackToolStripMenuItem, globalCommandLineArgumentsexpertsOnluToolStripMenuItem, epilepsyProtectionToolStripMenuItem, toolStripMenuItem5, saveSettingsToNESMiniNowToolStripMenuItem });
            settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            resources.ApplyResources(settingsToolStripMenuItem, "settingsToolStripMenuItem");
            // 
            // languageToolStripMenuItem
            // 
            resources.ApplyResources(languageToolStripMenuItem, "languageToolStripMenuItem");
            languageToolStripMenuItem.Name = "languageToolStripMenuItem";
            // 
            // segaUiThemeToolStripMenuItem
            // 
            segaUiThemeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { autoToolStripMenuItem, unitedStatesToolStripMenuItem, europeToolStripMenuItem, japanToolStripMenuItem });
            segaUiThemeToolStripMenuItem.Name = "segaUiThemeToolStripMenuItem";
            resources.ApplyResources(segaUiThemeToolStripMenuItem, "segaUiThemeToolStripMenuItem");
            // 
            // autoToolStripMenuItem
            // 
            autoToolStripMenuItem.Name = "autoToolStripMenuItem";
            resources.ApplyResources(autoToolStripMenuItem, "autoToolStripMenuItem");
            autoToolStripMenuItem.Tag = "auto";
            autoToolStripMenuItem.Click += changeM2Theme;
            // 
            // unitedStatesToolStripMenuItem
            // 
            unitedStatesToolStripMenuItem.Name = "unitedStatesToolStripMenuItem";
            resources.ApplyResources(unitedStatesToolStripMenuItem, "unitedStatesToolStripMenuItem");
            unitedStatesToolStripMenuItem.Tag = "us";
            unitedStatesToolStripMenuItem.Click += changeM2Theme;
            // 
            // europeToolStripMenuItem
            // 
            europeToolStripMenuItem.Name = "europeToolStripMenuItem";
            resources.ApplyResources(europeToolStripMenuItem, "europeToolStripMenuItem");
            europeToolStripMenuItem.Tag = "eu";
            europeToolStripMenuItem.Click += changeM2Theme;
            // 
            // japanToolStripMenuItem
            // 
            japanToolStripMenuItem.Name = "japanToolStripMenuItem";
            resources.ApplyResources(japanToolStripMenuItem, "japanToolStripMenuItem");
            japanToolStripMenuItem.Tag = "jp";
            japanToolStripMenuItem.Click += changeM2Theme;
            // 
            // sFROMToolToolStripMenuItem
            // 
            sFROMToolToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { enableSFROMToolToolStripMenuItem, usePCMPatchWhenAvailableToolStripMenuItem });
            sFROMToolToolStripMenuItem.Name = "sFROMToolToolStripMenuItem";
            resources.ApplyResources(sFROMToolToolStripMenuItem, "sFROMToolToolStripMenuItem");
            // 
            // enableSFROMToolToolStripMenuItem
            // 
            enableSFROMToolToolStripMenuItem.CheckOnClick = true;
            enableSFROMToolToolStripMenuItem.Name = "enableSFROMToolToolStripMenuItem";
            resources.ApplyResources(enableSFROMToolToolStripMenuItem, "enableSFROMToolToolStripMenuItem");
            enableSFROMToolToolStripMenuItem.Click += enableSFROMToolToolStripMenuItem_Click;
            // 
            // usePCMPatchWhenAvailableToolStripMenuItem
            // 
            usePCMPatchWhenAvailableToolStripMenuItem.CheckOnClick = true;
            usePCMPatchWhenAvailableToolStripMenuItem.Name = "usePCMPatchWhenAvailableToolStripMenuItem";
            resources.ApplyResources(usePCMPatchWhenAvailableToolStripMenuItem, "usePCMPatchWhenAvailableToolStripMenuItem");
            usePCMPatchWhenAvailableToolStripMenuItem.Click += usePCMPatchWhenAvailableToolStripMenuItem_Click;
            // 
            // convertSNESROMSToSFROMToolStripMenuItem
            // 
            convertSNESROMSToSFROMToolStripMenuItem.Checked = true;
            convertSNESROMSToSFROMToolStripMenuItem.CheckOnClick = true;
            convertSNESROMSToSFROMToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            convertSNESROMSToSFROMToolStripMenuItem.Name = "convertSNESROMSToSFROMToolStripMenuItem";
            resources.ApplyResources(convertSNESROMSToSFROMToolStripMenuItem, "convertSNESROMSToSFROMToolStripMenuItem");
            convertSNESROMSToSFROMToolStripMenuItem.Click += convertSNESROMSToSFROMToolStripMenuItem_Click;
            // 
            // separateGamesStorageToolStripMenuItem
            // 
            separateGamesStorageToolStripMenuItem.Checked = true;
            separateGamesStorageToolStripMenuItem.CheckOnClick = true;
            separateGamesStorageToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            separateGamesStorageToolStripMenuItem.Name = "separateGamesStorageToolStripMenuItem";
            resources.ApplyResources(separateGamesStorageToolStripMenuItem, "separateGamesStorageToolStripMenuItem");
            separateGamesStorageToolStripMenuItem.Click += separateGamesStorageToolStripMenuItem_Click;
            // 
            // compressGamesToolStripMenuItem
            // 
            compressGamesToolStripMenuItem.Checked = true;
            compressGamesToolStripMenuItem.CheckOnClick = true;
            compressGamesToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            compressGamesToolStripMenuItem.Name = "compressGamesToolStripMenuItem";
            resources.ApplyResources(compressGamesToolStripMenuItem, "compressGamesToolStripMenuItem");
            compressGamesToolStripMenuItem.Click += compressGamesToolStripMenuItem_Click;
            // 
            // compressBoxArtToolStripMenuItem
            // 
            compressBoxArtToolStripMenuItem.Checked = true;
            compressBoxArtToolStripMenuItem.CheckOnClick = true;
            compressBoxArtToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            compressBoxArtToolStripMenuItem.Name = "compressBoxArtToolStripMenuItem";
            resources.ApplyResources(compressBoxArtToolStripMenuItem, "compressBoxArtToolStripMenuItem");
            compressBoxArtToolStripMenuItem.Click += compressBoxArtToolStripMenuItem_Click;
            // 
            // centerBoxArtThumbnailToolStripMenuItem
            // 
            centerBoxArtThumbnailToolStripMenuItem.Checked = true;
            centerBoxArtThumbnailToolStripMenuItem.CheckOnClick = true;
            centerBoxArtThumbnailToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            centerBoxArtThumbnailToolStripMenuItem.Name = "centerBoxArtThumbnailToolStripMenuItem";
            resources.ApplyResources(centerBoxArtThumbnailToolStripMenuItem, "centerBoxArtThumbnailToolStripMenuItem");
            centerBoxArtThumbnailToolStripMenuItem.Click += centerBoxArtThumbnailToolStripMenuItem_Click;
            // 
            // disableHakchi2PopupsToolStripMenuItem
            // 
            disableHakchi2PopupsToolStripMenuItem.Checked = true;
            disableHakchi2PopupsToolStripMenuItem.CheckOnClick = true;
            disableHakchi2PopupsToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            disableHakchi2PopupsToolStripMenuItem.Name = "disableHakchi2PopupsToolStripMenuItem";
            resources.ApplyResources(disableHakchi2PopupsToolStripMenuItem, "disableHakchi2PopupsToolStripMenuItem");
            disableHakchi2PopupsToolStripMenuItem.Click += disableHakchi2PopupsToolStripMenuItem_Click;
            // 
            // enableInformationScrapeOnImportToolStripMenuItem
            // 
            enableInformationScrapeOnImportToolStripMenuItem.Checked = true;
            enableInformationScrapeOnImportToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            enableInformationScrapeOnImportToolStripMenuItem.Name = "enableInformationScrapeOnImportToolStripMenuItem";
            resources.ApplyResources(enableInformationScrapeOnImportToolStripMenuItem, "enableInformationScrapeOnImportToolStripMenuItem");
            enableInformationScrapeOnImportToolStripMenuItem.Click += enableInformationScrapeOnImportToolStripMenuItem_Click;
            // 
            // toolStripMenuItem25
            // 
            toolStripMenuItem25.Name = "toolStripMenuItem25";
            resources.ApplyResources(toolStripMenuItem25, "toolStripMenuItem25");
            // 
            // developerToolsToolStripMenuItem
            // 
            developerToolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { devForceSshToolStripMenuItem, uploadTotmpforTestingToolStripMenuItem, toolStripMenuItem23, forceNetworkMembootsToolStripMenuItem, forceClovershellMembootsToolStripMenuItem, downloadLatestHakchiToolStripMenuItem });
            developerToolsToolStripMenuItem.Name = "developerToolsToolStripMenuItem";
            resources.ApplyResources(developerToolsToolStripMenuItem, "developerToolsToolStripMenuItem");
            // 
            // devForceSshToolStripMenuItem
            // 
            devForceSshToolStripMenuItem.CheckOnClick = true;
            devForceSshToolStripMenuItem.Name = "devForceSshToolStripMenuItem";
            resources.ApplyResources(devForceSshToolStripMenuItem, "devForceSshToolStripMenuItem");
            devForceSshToolStripMenuItem.Click += devForceSshToolStripMenuItem_Click;
            // 
            // uploadTotmpforTestingToolStripMenuItem
            // 
            uploadTotmpforTestingToolStripMenuItem.CheckOnClick = true;
            uploadTotmpforTestingToolStripMenuItem.Name = "uploadTotmpforTestingToolStripMenuItem";
            resources.ApplyResources(uploadTotmpforTestingToolStripMenuItem, "uploadTotmpforTestingToolStripMenuItem");
            uploadTotmpforTestingToolStripMenuItem.Click += uploadTotmpforTestingToolStripMenuItem_Click;
            // 
            // toolStripMenuItem23
            // 
            toolStripMenuItem23.Name = "toolStripMenuItem23";
            resources.ApplyResources(toolStripMenuItem23, "toolStripMenuItem23");
            // 
            // forceNetworkMembootsToolStripMenuItem
            // 
            forceNetworkMembootsToolStripMenuItem.CheckOnClick = true;
            forceNetworkMembootsToolStripMenuItem.Name = "forceNetworkMembootsToolStripMenuItem";
            resources.ApplyResources(forceNetworkMembootsToolStripMenuItem, "forceNetworkMembootsToolStripMenuItem");
            forceNetworkMembootsToolStripMenuItem.Click += forceNetworkMembootsToolStripMenuItem_Click;
            // 
            // forceClovershellMembootsToolStripMenuItem
            // 
            forceClovershellMembootsToolStripMenuItem.CheckOnClick = true;
            forceClovershellMembootsToolStripMenuItem.Name = "forceClovershellMembootsToolStripMenuItem";
            resources.ApplyResources(forceClovershellMembootsToolStripMenuItem, "forceClovershellMembootsToolStripMenuItem");
            forceClovershellMembootsToolStripMenuItem.Click += forceClovershellMembootsToolStripMenuItem_Click;
            // 
            // downloadLatestHakchiToolStripMenuItem
            // 
            downloadLatestHakchiToolStripMenuItem.Name = "downloadLatestHakchiToolStripMenuItem";
            resources.ApplyResources(downloadLatestHakchiToolStripMenuItem, "downloadLatestHakchiToolStripMenuItem");
            downloadLatestHakchiToolStripMenuItem.Click += DownloadLatestHakchiToolStripMenuItem_Click;
            // 
            // separateGamesForMultibootToolStripMenuItem
            // 
            separateGamesForMultibootToolStripMenuItem.Checked = true;
            separateGamesForMultibootToolStripMenuItem.CheckOnClick = true;
            separateGamesForMultibootToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            separateGamesForMultibootToolStripMenuItem.Name = "separateGamesForMultibootToolStripMenuItem";
            resources.ApplyResources(separateGamesForMultibootToolStripMenuItem, "separateGamesForMultibootToolStripMenuItem");
            separateGamesForMultibootToolStripMenuItem.Click += separateGamesForMultibootToolStripMenuItem_Click;
            // 
            // alwaysCopyOriginalGamesToolStripMenuItem
            // 
            alwaysCopyOriginalGamesToolStripMenuItem.Checked = true;
            alwaysCopyOriginalGamesToolStripMenuItem.CheckOnClick = true;
            alwaysCopyOriginalGamesToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            alwaysCopyOriginalGamesToolStripMenuItem.Name = "alwaysCopyOriginalGamesToolStripMenuItem";
            resources.ApplyResources(alwaysCopyOriginalGamesToolStripMenuItem, "alwaysCopyOriginalGamesToolStripMenuItem");
            alwaysCopyOriginalGamesToolStripMenuItem.Click += alwaysCopyOriginalGamesToolStripMenuItem_Click;
            // 
            // useLinkedSyncToolStripMenuItem
            // 
            useLinkedSyncToolStripMenuItem.Checked = true;
            useLinkedSyncToolStripMenuItem.CheckOnClick = true;
            useLinkedSyncToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            useLinkedSyncToolStripMenuItem.Name = "useLinkedSyncToolStripMenuItem";
            resources.ApplyResources(useLinkedSyncToolStripMenuItem, "useLinkedSyncToolStripMenuItem");
            useLinkedSyncToolStripMenuItem.Click += useLinkedSyncToolStripMenuItem_Click;
            // 
            // toolStripMenuItem16
            // 
            toolStripMenuItem16.Name = "toolStripMenuItem16";
            resources.ApplyResources(toolStripMenuItem16, "toolStripMenuItem16");
            // 
            // cloverconHackToolStripMenuItem
            // 
            cloverconHackToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { resetUsingCombinationOfButtonsToolStripMenuItem, selectButtonCombinationToolStripMenuItem, enableAutofireToolStripMenuItem, useXYOnClassicControllerAsAutofireABToolStripMenuItem, upABStartOnSecondControllerToolStripMenuItem });
            cloverconHackToolStripMenuItem.Name = "cloverconHackToolStripMenuItem";
            resources.ApplyResources(cloverconHackToolStripMenuItem, "cloverconHackToolStripMenuItem");
            // 
            // resetUsingCombinationOfButtonsToolStripMenuItem
            // 
            resetUsingCombinationOfButtonsToolStripMenuItem.Checked = true;
            resetUsingCombinationOfButtonsToolStripMenuItem.CheckOnClick = true;
            resetUsingCombinationOfButtonsToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            resetUsingCombinationOfButtonsToolStripMenuItem.Name = "resetUsingCombinationOfButtonsToolStripMenuItem";
            resources.ApplyResources(resetUsingCombinationOfButtonsToolStripMenuItem, "resetUsingCombinationOfButtonsToolStripMenuItem");
            resetUsingCombinationOfButtonsToolStripMenuItem.Click += cloverconHackToolStripMenuItem_Click;
            // 
            // selectButtonCombinationToolStripMenuItem
            // 
            selectButtonCombinationToolStripMenuItem.Name = "selectButtonCombinationToolStripMenuItem";
            resources.ApplyResources(selectButtonCombinationToolStripMenuItem, "selectButtonCombinationToolStripMenuItem");
            selectButtonCombinationToolStripMenuItem.Click += selectButtonCombinationToolStripMenuItem_Click;
            // 
            // enableAutofireToolStripMenuItem
            // 
            enableAutofireToolStripMenuItem.CheckOnClick = true;
            enableAutofireToolStripMenuItem.Name = "enableAutofireToolStripMenuItem";
            resources.ApplyResources(enableAutofireToolStripMenuItem, "enableAutofireToolStripMenuItem");
            enableAutofireToolStripMenuItem.Click += enableAutofireToolStripMenuItem_Click;
            // 
            // useXYOnClassicControllerAsAutofireABToolStripMenuItem
            // 
            useXYOnClassicControllerAsAutofireABToolStripMenuItem.CheckOnClick = true;
            useXYOnClassicControllerAsAutofireABToolStripMenuItem.Name = "useXYOnClassicControllerAsAutofireABToolStripMenuItem";
            resources.ApplyResources(useXYOnClassicControllerAsAutofireABToolStripMenuItem, "useXYOnClassicControllerAsAutofireABToolStripMenuItem");
            useXYOnClassicControllerAsAutofireABToolStripMenuItem.Click += useXYOnClassicControllerAsAutofireABToolStripMenuItem_Click;
            // 
            // upABStartOnSecondControllerToolStripMenuItem
            // 
            upABStartOnSecondControllerToolStripMenuItem.CheckOnClick = true;
            upABStartOnSecondControllerToolStripMenuItem.Name = "upABStartOnSecondControllerToolStripMenuItem";
            resources.ApplyResources(upABStartOnSecondControllerToolStripMenuItem, "upABStartOnSecondControllerToolStripMenuItem");
            upABStartOnSecondControllerToolStripMenuItem.Click += upABStartOnSecondControllerToolStripMenuItem_Click;
            // 
            // globalCommandLineArgumentsexpertsOnluToolStripMenuItem
            // 
            globalCommandLineArgumentsexpertsOnluToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { kachikachiToolStripMenuItem, canoeToolStripMenuItem, retroarchToolStripMenuItem });
            globalCommandLineArgumentsexpertsOnluToolStripMenuItem.Name = "globalCommandLineArgumentsexpertsOnluToolStripMenuItem";
            resources.ApplyResources(globalCommandLineArgumentsexpertsOnluToolStripMenuItem, "globalCommandLineArgumentsexpertsOnluToolStripMenuItem");
            // 
            // kachikachiToolStripMenuItem
            // 
            kachikachiToolStripMenuItem.Name = "kachikachiToolStripMenuItem";
            resources.ApplyResources(kachikachiToolStripMenuItem, "kachikachiToolStripMenuItem");
            kachikachiToolStripMenuItem.Tag = "0";
            kachikachiToolStripMenuItem.Click += globalCommandLineArgumentsexpertsOnluToolStripMenuItem_Click;
            // 
            // canoeToolStripMenuItem
            // 
            canoeToolStripMenuItem.Name = "canoeToolStripMenuItem";
            resources.ApplyResources(canoeToolStripMenuItem, "canoeToolStripMenuItem");
            canoeToolStripMenuItem.Tag = "1";
            canoeToolStripMenuItem.Click += globalCommandLineArgumentsexpertsOnluToolStripMenuItem_Click;
            // 
            // retroarchToolStripMenuItem
            // 
            retroarchToolStripMenuItem.Name = "retroarchToolStripMenuItem";
            resources.ApplyResources(retroarchToolStripMenuItem, "retroarchToolStripMenuItem");
            retroarchToolStripMenuItem.Tag = "2";
            retroarchToolStripMenuItem.Click += globalCommandLineArgumentsexpertsOnluToolStripMenuItem_Click;
            // 
            // epilepsyProtectionToolStripMenuItem
            // 
            epilepsyProtectionToolStripMenuItem.Checked = true;
            epilepsyProtectionToolStripMenuItem.CheckOnClick = true;
            epilepsyProtectionToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            epilepsyProtectionToolStripMenuItem.Name = "epilepsyProtectionToolStripMenuItem";
            resources.ApplyResources(epilepsyProtectionToolStripMenuItem, "epilepsyProtectionToolStripMenuItem");
            epilepsyProtectionToolStripMenuItem.Click += ToolStripMenuItemArmet_Click;
            // 
            // toolStripMenuItem5
            // 
            toolStripMenuItem5.Name = "toolStripMenuItem5";
            resources.ApplyResources(toolStripMenuItem5, "toolStripMenuItem5");
            // 
            // saveSettingsToNESMiniNowToolStripMenuItem
            // 
            resources.ApplyResources(saveSettingsToNESMiniNowToolStripMenuItem, "saveSettingsToNESMiniNowToolStripMenuItem");
            saveSettingsToNESMiniNowToolStripMenuItem.Name = "saveSettingsToNESMiniNowToolStripMenuItem";
            saveSettingsToNESMiniNowToolStripMenuItem.Click += saveSettingsToNESMiniNowToolStripMenuItem_Click;
            // 
            // toolsToolStripMenuItem
            // 
            toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { saveStateManagerToolStripMenuItem, importGamesFromMiniToolStripMenuItem, takeScreenshotToolStripMenuItem, saveDmesgOutputToolStripMenuItem, toolStripMenuItem6, openFTPInExplorerToolStripMenuItem, openTelnetToolStripMenuItem, toolStripMenuItem8, bootImageToolStripMenuItem, rebootToolStripMenuItem, switchRunningFirmwareToolStripMenuItem, formatSDCardToolStripMenuItem, toolStripMenuItem18, prepareArtDirectoryToolStripMenuItem });
            toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            resources.ApplyResources(toolsToolStripMenuItem, "toolsToolStripMenuItem");
            // 
            // saveStateManagerToolStripMenuItem
            // 
            saveStateManagerToolStripMenuItem.Name = "saveStateManagerToolStripMenuItem";
            resources.ApplyResources(saveStateManagerToolStripMenuItem, "saveStateManagerToolStripMenuItem");
            saveStateManagerToolStripMenuItem.Click += saveStateManagerToolStripMenuItem_Click;
            // 
            // importGamesFromMiniToolStripMenuItem
            // 
            importGamesFromMiniToolStripMenuItem.Name = "importGamesFromMiniToolStripMenuItem";
            resources.ApplyResources(importGamesFromMiniToolStripMenuItem, "importGamesFromMiniToolStripMenuItem");
            importGamesFromMiniToolStripMenuItem.Click += importGamesFromMiniToolStripMenuItem_Click;
            // 
            // takeScreenshotToolStripMenuItem
            // 
            takeScreenshotToolStripMenuItem.Name = "takeScreenshotToolStripMenuItem";
            resources.ApplyResources(takeScreenshotToolStripMenuItem, "takeScreenshotToolStripMenuItem");
            takeScreenshotToolStripMenuItem.Click += takeScreenshotToolStripMenuItem_Click;
            // 
            // saveDmesgOutputToolStripMenuItem
            // 
            saveDmesgOutputToolStripMenuItem.Name = "saveDmesgOutputToolStripMenuItem";
            resources.ApplyResources(saveDmesgOutputToolStripMenuItem, "saveDmesgOutputToolStripMenuItem");
            saveDmesgOutputToolStripMenuItem.Click += saveDmesgOutputToolStripMenuItem_Click;
            // 
            // toolStripMenuItem6
            // 
            toolStripMenuItem6.Name = "toolStripMenuItem6";
            resources.ApplyResources(toolStripMenuItem6, "toolStripMenuItem6");
            // 
            // openFTPInExplorerToolStripMenuItem
            // 
            resources.ApplyResources(openFTPInExplorerToolStripMenuItem, "openFTPInExplorerToolStripMenuItem");
            openFTPInExplorerToolStripMenuItem.Name = "openFTPInExplorerToolStripMenuItem";
            openFTPInExplorerToolStripMenuItem.Click += openFTPInExplorerToolStripMenuItem_Click;
            // 
            // openTelnetToolStripMenuItem
            // 
            resources.ApplyResources(openTelnetToolStripMenuItem, "openTelnetToolStripMenuItem");
            openTelnetToolStripMenuItem.Name = "openTelnetToolStripMenuItem";
            openTelnetToolStripMenuItem.Click += openTelnetToolStripMenuItem_Click;
            // 
            // toolStripMenuItem8
            // 
            toolStripMenuItem8.Name = "toolStripMenuItem8";
            resources.ApplyResources(toolStripMenuItem8, "toolStripMenuItem8");
            // 
            // bootImageToolStripMenuItem
            // 
            bootImageToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { changeBootImageToolStripMenuItem, disableBootImageToolStripMenuItem, resetDefaultBootImageToolStripMenuItem });
            bootImageToolStripMenuItem.Name = "bootImageToolStripMenuItem";
            resources.ApplyResources(bootImageToolStripMenuItem, "bootImageToolStripMenuItem");
            // 
            // changeBootImageToolStripMenuItem
            // 
            changeBootImageToolStripMenuItem.Name = "changeBootImageToolStripMenuItem";
            resources.ApplyResources(changeBootImageToolStripMenuItem, "changeBootImageToolStripMenuItem");
            changeBootImageToolStripMenuItem.Click += changeBootImageToolStripMenuItem_Click;
            // 
            // disableBootImageToolStripMenuItem
            // 
            disableBootImageToolStripMenuItem.Name = "disableBootImageToolStripMenuItem";
            resources.ApplyResources(disableBootImageToolStripMenuItem, "disableBootImageToolStripMenuItem");
            disableBootImageToolStripMenuItem.Click += disableBootImageToolStripMenuItem_Click;
            // 
            // resetDefaultBootImageToolStripMenuItem
            // 
            resetDefaultBootImageToolStripMenuItem.Name = "resetDefaultBootImageToolStripMenuItem";
            resources.ApplyResources(resetDefaultBootImageToolStripMenuItem, "resetDefaultBootImageToolStripMenuItem");
            resetDefaultBootImageToolStripMenuItem.Click += resetDefaultBootImageToolStripMenuItem_Click;
            // 
            // rebootToolStripMenuItem
            // 
            rebootToolStripMenuItem.Name = "rebootToolStripMenuItem";
            resources.ApplyResources(rebootToolStripMenuItem, "rebootToolStripMenuItem");
            rebootToolStripMenuItem.Click += rebootToolStripMenuItem_Click;
            // 
            // switchRunningFirmwareToolStripMenuItem
            // 
            switchRunningFirmwareToolStripMenuItem.Name = "switchRunningFirmwareToolStripMenuItem";
            resources.ApplyResources(switchRunningFirmwareToolStripMenuItem, "switchRunningFirmwareToolStripMenuItem");
            switchRunningFirmwareToolStripMenuItem.Click += switchRunningFirmwareToolStripMenuItem_Click;
            // 
            // formatSDCardToolStripMenuItem
            // 
            resources.ApplyResources(formatSDCardToolStripMenuItem, "formatSDCardToolStripMenuItem");
            formatSDCardToolStripMenuItem.Name = "formatSDCardToolStripMenuItem";
            formatSDCardToolStripMenuItem.Click += formatSDCardToolStripMenuItem_Click;
            // 
            // toolStripMenuItem18
            // 
            toolStripMenuItem18.Name = "toolStripMenuItem18";
            resources.ApplyResources(toolStripMenuItem18, "toolStripMenuItem18");
            // 
            // prepareArtDirectoryToolStripMenuItem
            // 
            prepareArtDirectoryToolStripMenuItem.Image = Properties.Resources.folder_sm;
            prepareArtDirectoryToolStripMenuItem.Name = "prepareArtDirectoryToolStripMenuItem";
            resources.ApplyResources(prepareArtDirectoryToolStripMenuItem, "prepareArtDirectoryToolStripMenuItem");
            prepareArtDirectoryToolStripMenuItem.Click += prepareArtDirectoryToolStripMenuItem_Click;
            // 
            // bluetoothToolStripMenuItem
            // 
            bluetoothToolStripMenuItem.Name = "bluetoothToolStripMenuItem";
            resources.ApplyResources(bluetoothToolStripMenuItem, "bluetoothToolStripMenuItem");
            // 
            // helpToolStripMenuItem
            // 
            helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { gitHubPageWithActualReleasesToolStripMenuItem, joinOurDiscordServerToolStripMenuItem, rRockinTheClassicsToolStripMenuItem, donateToolStripMenuItem, fAQToolStripMenuItem, toolStripMenuItem22, technicalInformationToolStripMenuItem, messageOfTheDayToolStripMenuItem, aboutToolStripMenuItem });
            helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            resources.ApplyResources(helpToolStripMenuItem, "helpToolStripMenuItem");
            // 
            // gitHubPageWithActualReleasesToolStripMenuItem
            // 
            gitHubPageWithActualReleasesToolStripMenuItem.Image = Properties.Resources.github;
            gitHubPageWithActualReleasesToolStripMenuItem.Name = "gitHubPageWithActualReleasesToolStripMenuItem";
            resources.ApplyResources(gitHubPageWithActualReleasesToolStripMenuItem, "gitHubPageWithActualReleasesToolStripMenuItem");
            gitHubPageWithActualReleasesToolStripMenuItem.Tag = "https://github.com/Exeqtr-RED/Hakchi3";
            gitHubPageWithActualReleasesToolStripMenuItem.Click += openWebsiteLink;
            // 
            // joinOurDiscordServerToolStripMenuItem
            // 
            joinOurDiscordServerToolStripMenuItem.Image = Properties.Resources.discord;
            joinOurDiscordServerToolStripMenuItem.Name = "joinOurDiscordServerToolStripMenuItem";
            resources.ApplyResources(joinOurDiscordServerToolStripMenuItem, "joinOurDiscordServerToolStripMenuItem");
            joinOurDiscordServerToolStripMenuItem.Tag = "https://discord.gg/C9EDFyg";
            joinOurDiscordServerToolStripMenuItem.Click += openWebsiteLink;
            // 
            // rRockinTheClassicsToolStripMenuItem
            // 
            rRockinTheClassicsToolStripMenuItem.Image = Properties.Resources.reddit;
            rRockinTheClassicsToolStripMenuItem.Name = "rRockinTheClassicsToolStripMenuItem";
            resources.ApplyResources(rRockinTheClassicsToolStripMenuItem, "rRockinTheClassicsToolStripMenuItem");
            rRockinTheClassicsToolStripMenuItem.Tag = "https://www.reddit.com/r/RockinTheClassics/";
            rRockinTheClassicsToolStripMenuItem.Click += openWebsiteLink;
            // 
            // donateToolStripMenuItem
            // 
            donateToolStripMenuItem.Image = Properties.Resources.paypal;
            donateToolStripMenuItem.Name = "donateToolStripMenuItem";
            resources.ApplyResources(donateToolStripMenuItem, "donateToolStripMenuItem");
            donateToolStripMenuItem.Tag = "https://www.paypal.me/clusterm";
            donateToolStripMenuItem.Click += openWebsiteLink;
            // 
            // fAQToolStripMenuItem
            // 
            fAQToolStripMenuItem.Name = "fAQToolStripMenuItem";
            resources.ApplyResources(fAQToolStripMenuItem, "fAQToolStripMenuItem");
            fAQToolStripMenuItem.Tag = "https://github.com/TeamShinkansen/hakchi2/wiki/FAQ";
            fAQToolStripMenuItem.Click += openWebsiteLink;
            // 
            // toolStripMenuItem22
            // 
            toolStripMenuItem22.Name = "toolStripMenuItem22";
            resources.ApplyResources(toolStripMenuItem22, "toolStripMenuItem22");
            // 
            // technicalInformationToolStripMenuItem
            // 
            technicalInformationToolStripMenuItem.Name = "technicalInformationToolStripMenuItem";
            resources.ApplyResources(technicalInformationToolStripMenuItem, "technicalInformationToolStripMenuItem");
            technicalInformationToolStripMenuItem.Click += technicalInformationToolStripMenuItem_Click;
            // 
            // messageOfTheDayToolStripMenuItem
            // 
            messageOfTheDayToolStripMenuItem.Name = "messageOfTheDayToolStripMenuItem";
            resources.ApplyResources(messageOfTheDayToolStripMenuItem, "messageOfTheDayToolStripMenuItem");
            messageOfTheDayToolStripMenuItem.Click += messageOfTheDayToolStripMenuItem_Click;
            // 
            // aboutToolStripMenuItem
            // 
            aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            resources.ApplyResources(aboutToolStripMenuItem, "aboutToolStripMenuItem");
            aboutToolStripMenuItem.Click += aboutToolStripMenuItem_Click;
            // 
            // buttonAddGames
            // 
            resources.ApplyResources(buttonAddGames, "buttonAddGames");
            buttonAddGames.Name = "buttonAddGames";
            buttonAddGames.UseVisualStyleBackColor = true;
            buttonAddGames.Click += buttonAddGames_Click;
            // 
            // openFileDialogNes
            // 
            openFileDialogNes.DefaultExt = "nes";
            openFileDialogNes.Multiselect = true;
            resources.ApplyResources(openFileDialogNes, "openFileDialogNes");
            // 
            // contextMenuStrip
            // 
            contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { explorerToolStripMenuItem, toolStripSeparator2, addPrefixToolStripMenuItem, removePrefixToolStripMenuItem, toolStripMenuItem14, setRegionToolStripMenuItem, toolStripSeparator3, scrapeSelectedGamesToolStripMenuItem, scanForNewBoxArtForSelectedGamesToolStripMenuItem, downloadBoxArtForSelectedGamesToolStripMenuItem, deleteSelectedGamesBoxArtToolStripMenuItem, toolStripMenuItem15, archiveSelectedGamesToolStripMenuItem, compressSelectedGamesToolStripMenuItem, decompressSelectedGamesToolStripMenuItem, deleteSelectedGamesToolStripMenuItem, toolStripMenuItem17, sFROMToolToolStripMenuItem1, repairGamesToolStripMenuItem, toolStripMenuItem19, selectEmulationCoreToolStripMenuItem });
            contextMenuStrip.Name = "contextMenuStrip";
            resources.ApplyResources(contextMenuStrip, "contextMenuStrip");
            // 
            // explorerToolStripMenuItem
            // 
            resources.ApplyResources(explorerToolStripMenuItem, "explorerToolStripMenuItem");
            explorerToolStripMenuItem.Name = "explorerToolStripMenuItem";
            explorerToolStripMenuItem.Click += explorerToolStripMenuItem_Click;
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            resources.ApplyResources(toolStripSeparator2, "toolStripSeparator2");
            // 
            // addPrefixToolStripMenuItem
            // 
            resources.ApplyResources(addPrefixToolStripMenuItem, "addPrefixToolStripMenuItem");
            addPrefixToolStripMenuItem.Name = "addPrefixToolStripMenuItem";
            addPrefixToolStripMenuItem.Click += addPrefixToolStripMenuItem_Click;
            // 
            // removePrefixToolStripMenuItem
            // 
            resources.ApplyResources(removePrefixToolStripMenuItem, "removePrefixToolStripMenuItem");
            removePrefixToolStripMenuItem.Name = "removePrefixToolStripMenuItem";
            removePrefixToolStripMenuItem.Click += removePrefixToolStripMenuItem_Click;
            // 
            // toolStripMenuItem14
            // 
            toolStripMenuItem14.Name = "toolStripMenuItem14";
            resources.ApplyResources(toolStripMenuItem14, "toolStripMenuItem14");
            // 
            // setRegionToolStripMenuItem
            // 
            setRegionToolStripMenuItem.Name = "setRegionToolStripMenuItem";
            resources.ApplyResources(setRegionToolStripMenuItem, "setRegionToolStripMenuItem");
            // 
            // toolStripSeparator3
            // 
            toolStripSeparator3.Name = "toolStripSeparator3";
            resources.ApplyResources(toolStripSeparator3, "toolStripSeparator3");
            // 
            // scrapeSelectedGamesToolStripMenuItem
            // 
            resources.ApplyResources(scrapeSelectedGamesToolStripMenuItem, "scrapeSelectedGamesToolStripMenuItem");
            scrapeSelectedGamesToolStripMenuItem.Name = "scrapeSelectedGamesToolStripMenuItem";
            scrapeSelectedGamesToolStripMenuItem.Click += scrapeSelectedGamesToolStripMenuItem_Click;
            // 
            // scanForNewBoxArtForSelectedGamesToolStripMenuItem
            // 
            resources.ApplyResources(scanForNewBoxArtForSelectedGamesToolStripMenuItem, "scanForNewBoxArtForSelectedGamesToolStripMenuItem");
            scanForNewBoxArtForSelectedGamesToolStripMenuItem.Name = "scanForNewBoxArtForSelectedGamesToolStripMenuItem";
            scanForNewBoxArtForSelectedGamesToolStripMenuItem.Click += scanForNewBoxArtForSelectedGamesToolStripMenuItem_Click;
            // 
            // downloadBoxArtForSelectedGamesToolStripMenuItem
            // 
            resources.ApplyResources(downloadBoxArtForSelectedGamesToolStripMenuItem, "downloadBoxArtForSelectedGamesToolStripMenuItem");
            downloadBoxArtForSelectedGamesToolStripMenuItem.Name = "downloadBoxArtForSelectedGamesToolStripMenuItem";
            downloadBoxArtForSelectedGamesToolStripMenuItem.Click += downloadBoxArtForSelectedGamesToolStripMenuItem_Click;
            // 
            // deleteSelectedGamesBoxArtToolStripMenuItem
            // 
            resources.ApplyResources(deleteSelectedGamesBoxArtToolStripMenuItem, "deleteSelectedGamesBoxArtToolStripMenuItem");
            deleteSelectedGamesBoxArtToolStripMenuItem.Name = "deleteSelectedGamesBoxArtToolStripMenuItem";
            deleteSelectedGamesBoxArtToolStripMenuItem.Click += deleteSelectedGamesBoxArtToolStripMenuItem_Click;
            // 
            // toolStripMenuItem15
            // 
            toolStripMenuItem15.Name = "toolStripMenuItem15";
            resources.ApplyResources(toolStripMenuItem15, "toolStripMenuItem15");
            // 
            // archiveSelectedGamesToolStripMenuItem
            // 
            resources.ApplyResources(archiveSelectedGamesToolStripMenuItem, "archiveSelectedGamesToolStripMenuItem");
            archiveSelectedGamesToolStripMenuItem.Name = "archiveSelectedGamesToolStripMenuItem";
            archiveSelectedGamesToolStripMenuItem.Click += archiveSelectedGamesToolStripMenuItem_Click;
            // 
            // compressSelectedGamesToolStripMenuItem
            // 
            resources.ApplyResources(compressSelectedGamesToolStripMenuItem, "compressSelectedGamesToolStripMenuItem");
            compressSelectedGamesToolStripMenuItem.Name = "compressSelectedGamesToolStripMenuItem";
            compressSelectedGamesToolStripMenuItem.Click += compressSelectedGamesToolStripMenuItem_Click;
            // 
            // decompressSelectedGamesToolStripMenuItem
            // 
            resources.ApplyResources(decompressSelectedGamesToolStripMenuItem, "decompressSelectedGamesToolStripMenuItem");
            decompressSelectedGamesToolStripMenuItem.Name = "decompressSelectedGamesToolStripMenuItem";
            decompressSelectedGamesToolStripMenuItem.Click += decompressSelectedGamesToolStripMenuItem_Click;
            // 
            // deleteSelectedGamesToolStripMenuItem
            // 
            resources.ApplyResources(deleteSelectedGamesToolStripMenuItem, "deleteSelectedGamesToolStripMenuItem");
            deleteSelectedGamesToolStripMenuItem.Name = "deleteSelectedGamesToolStripMenuItem";
            deleteSelectedGamesToolStripMenuItem.Click += deleteSelectedGamesToolStripMenuItem_Click;
            // 
            // toolStripMenuItem17
            // 
            toolStripMenuItem17.Name = "toolStripMenuItem17";
            resources.ApplyResources(toolStripMenuItem17, "toolStripMenuItem17");
            // 
            // sFROMToolToolStripMenuItem1
            // 
            sFROMToolToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { editROMHeaderToolStripMenuItem, toolStripMenuItem9, resetROMHeaderToolStripMenuItem });
            sFROMToolToolStripMenuItem1.Name = "sFROMToolToolStripMenuItem1";
            resources.ApplyResources(sFROMToolToolStripMenuItem1, "sFROMToolToolStripMenuItem1");
            // 
            // editROMHeaderToolStripMenuItem
            // 
            editROMHeaderToolStripMenuItem.Name = "editROMHeaderToolStripMenuItem";
            resources.ApplyResources(editROMHeaderToolStripMenuItem, "editROMHeaderToolStripMenuItem");
            editROMHeaderToolStripMenuItem.Click += editROMHeaderToolStripMenuItem_Click;
            // 
            // toolStripMenuItem9
            // 
            toolStripMenuItem9.Name = "toolStripMenuItem9";
            resources.ApplyResources(toolStripMenuItem9, "toolStripMenuItem9");
            // 
            // resetROMHeaderToolStripMenuItem
            // 
            resetROMHeaderToolStripMenuItem.Name = "resetROMHeaderToolStripMenuItem";
            resources.ApplyResources(resetROMHeaderToolStripMenuItem, "resetROMHeaderToolStripMenuItem");
            resetROMHeaderToolStripMenuItem.Click += resetROMHeaderToolStripMenuItem_Click;
            // 
            // repairGamesToolStripMenuItem
            // 
            repairGamesToolStripMenuItem.Name = "repairGamesToolStripMenuItem";
            resources.ApplyResources(repairGamesToolStripMenuItem, "repairGamesToolStripMenuItem");
            repairGamesToolStripMenuItem.Click += repairGamesToolStripMenuItem_Click;
            // 
            // toolStripMenuItem19
            // 
            toolStripMenuItem19.Name = "toolStripMenuItem19";
            resources.ApplyResources(toolStripMenuItem19, "toolStripMenuItem19");
            // 
            // selectEmulationCoreToolStripMenuItem
            // 
            selectEmulationCoreToolStripMenuItem.Name = "selectEmulationCoreToolStripMenuItem";
            resources.ApplyResources(selectEmulationCoreToolStripMenuItem, "selectEmulationCoreToolStripMenuItem");
            selectEmulationCoreToolStripMenuItem.Click += selectEmulationCoreToolStripMenuItem_Click;
            // 
            // openFileDialogImage
            // 
            resources.ApplyResources(openFileDialogImage, "openFileDialogImage");
            // 
            // buttonStart
            // 
            resources.ApplyResources(buttonStart, "buttonStart");
            buttonStart.Name = "buttonStart";
            buttonStart.UseVisualStyleBackColor = true;
            buttonStart.Click += buttonStart_Click;
            // 
            // timerCalculateGames
            // 
            timerCalculateGames.Interval = 500;
            timerCalculateGames.Tick += timerCalculateGames_Tick;
            // 
            // timerConnectionCheck
            // 
            timerConnectionCheck.Interval = 500;
            timerConnectionCheck.Tick += timerConnectionCheck_Tick;
            // 
            // saveDumpFileDialog
            // 
            saveDumpFileDialog.DefaultExt = "bin";
            saveDumpFileDialog.FileName = "nand.bin";
            resources.ApplyResources(saveDumpFileDialog, "saveDumpFileDialog");
            // 
            // openDumpFileDialog
            // 
            openDumpFileDialog.FileName = "...";
            resources.ApplyResources(openDumpFileDialog, "openDumpFileDialog");
            // 
            // listViewGames
            // 
            listViewGames.CheckBoxes = true;
            listViewGames.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] { gameName });
            tableLayoutPanel3.SetColumnSpan(listViewGames, 2);
            resources.ApplyResources(listViewGames, "listViewGames");
            listViewGames.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            listViewGames.Name = "listViewGames";
            listViewGames.UseCompatibleStateImageBehavior = false;
            listViewGames.View = System.Windows.Forms.View.Details;
            listViewGames.ItemCheck += listViewGames_ItemCheck;
            listViewGames.ItemSelectionChanged += listViewGames_ItemSelectionChanged;
            listViewGames.KeyDown += listViewGames_KeyDown;
            listViewGames.MouseDown += listViewGames_MouseDown;
            listViewGames.Resize += listViewGames_Resize;
            // 
            // gameName
            // 
            resources.ApplyResources(gameName, "gameName");
            // 
            // timerShowSelected
            // 
            timerShowSelected.Interval = 50;
            timerShowSelected.Tick += timerShowSelected_Tick;
            // 
            // buttonExport
            // 
            resources.ApplyResources(buttonExport, "buttonExport");
            buttonExport.Name = "buttonExport";
            buttonExport.UseVisualStyleBackColor = true;
            buttonExport.Click += buttonExport_Click;
            // 
            // labelID
            // 
            resources.ApplyResources(labelID, "labelID");
            labelID.Name = "labelID";
            // 
            // textBoxName
            // 
            tableLayoutPanelGameInfo.SetColumnSpan(textBoxName, 2);
            resources.ApplyResources(textBoxName, "textBoxName");
            textBoxName.Name = "textBoxName";
            textBoxName.TextChanged += textBoxName_TextChanged;
            // 
            // labelPublisher
            // 
            resources.ApplyResources(labelPublisher, "labelPublisher");
            labelPublisher.Name = "labelPublisher";
            // 
            // textBoxPublisher
            // 
            tableLayoutPanelGameInfo.SetColumnSpan(textBoxPublisher, 2);
            resources.ApplyResources(textBoxPublisher, "textBoxPublisher");
            textBoxPublisher.Name = "textBoxPublisher";
            textBoxPublisher.TextChanged += textBoxPublisher_TextChanged;
            // 
            // labelCommandLine
            // 
            resources.ApplyResources(labelCommandLine, "labelCommandLine");
            tableLayoutPanelGameInfo.SetColumnSpan(labelCommandLine, 2);
            labelCommandLine.Name = "labelCommandLine";
            // 
            // textBoxArguments
            // 
            textBoxArguments.BackColor = System.Drawing.SystemColors.Window;
            tableLayoutPanelGameInfo.SetColumnSpan(textBoxArguments, 2);
            resources.ApplyResources(textBoxArguments, "textBoxArguments");
            textBoxArguments.Name = "textBoxArguments";
            textBoxArguments.TextChanged += textBoxArguments_TextChanged;
            // 
            // pictureBoxArt
            // 
            pictureBoxArt.AllowDrop = true;
            pictureBoxArt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(pictureBoxArt, "pictureBoxArt");
            pictureBoxArt.Name = "pictureBoxArt";
            pictureBoxArt.TabStop = false;
            pictureBoxArt.Tag = NesMenuElementBase.GameImageType.CloverFront;
            pictureBoxArt.DragDrop += pictureBoxArt_DragDrop;
            pictureBoxArt.DragEnter += pictureBoxArt_DragEnter;
            pictureBoxArt.MouseClick += pictureBoxArt_MouseClick;
            // 
            // buttonBrowseImage
            // 
            resources.ApplyResources(buttonBrowseImage, "buttonBrowseImage");
            buttonBrowseImage.Name = "buttonBrowseImage";
            buttonBrowseImage.Tag = NesMenuElementBase.GameImageType.AllFront;
            buttonBrowseImage.UseVisualStyleBackColor = true;
            buttonBrowseImage.MouseClick += pictureBoxArt_MouseClick;
            // 
            // buttonGoogle
            // 
            resources.ApplyResources(buttonGoogle, "buttonGoogle");
            buttonGoogle.Name = "buttonGoogle";
            buttonGoogle.UseVisualStyleBackColor = true;
            buttonGoogle.Click += buttonGoogle_Click;
            // 
            // labelMaxPlayers
            // 
            resources.ApplyResources(labelMaxPlayers, "labelMaxPlayers");
            labelMaxPlayers.Name = "labelMaxPlayers";
            // 
            // labelGameGenie
            // 
            resources.ApplyResources(labelGameGenie, "labelGameGenie");
            tableLayoutPanelGameInfo.SetColumnSpan(labelGameGenie, 2);
            labelGameGenie.Name = "labelGameGenie";
            // 
            // textBoxGameGenie
            // 
            textBoxGameGenie.BackColor = System.Drawing.SystemColors.Window;
            resources.ApplyResources(textBoxGameGenie, "textBoxGameGenie");
            textBoxGameGenie.Name = "textBoxGameGenie";
            textBoxGameGenie.TextChanged += textBoxGameGenie_TextChanged;
            // 
            // labelReleaseDate
            // 
            resources.ApplyResources(labelReleaseDate, "labelReleaseDate");
            tableLayoutPanelGameInfo.SetColumnSpan(labelReleaseDate, 2);
            labelReleaseDate.Name = "labelReleaseDate";
            // 
            // maskedTextBoxReleaseDate
            // 
            maskedTextBoxReleaseDate.BackColor = System.Drawing.SystemColors.Window;
            resources.ApplyResources(maskedTextBoxReleaseDate, "maskedTextBoxReleaseDate");
            maskedTextBoxReleaseDate.Name = "maskedTextBoxReleaseDate";
            maskedTextBoxReleaseDate.TextChanged += maskedTextBoxReleaseDate_TextChanged;
            // 
            // buttonShowGameGenieDatabase
            // 
            resources.ApplyResources(buttonShowGameGenieDatabase, "buttonShowGameGenieDatabase");
            buttonShowGameGenieDatabase.Name = "buttonShowGameGenieDatabase";
            buttonShowGameGenieDatabase.UseVisualStyleBackColor = true;
            buttonShowGameGenieDatabase.Click += buttonShowGameGenieDatabase_Click;
            // 
            // checkBoxCompressed
            // 
            resources.ApplyResources(checkBoxCompressed, "checkBoxCompressed");
            checkBoxCompressed.Name = "checkBoxCompressed";
            checkBoxCompressed.UseVisualStyleBackColor = true;
            checkBoxCompressed.Click += checkBoxCompressed_CheckedChanged;
            // 
            // labelSize
            // 
            resources.ApplyResources(labelSize, "labelSize");
            labelSize.Name = "labelSize";
            // 
            // buttonDefaultCover
            // 
            resources.ApplyResources(buttonDefaultCover, "buttonDefaultCover");
            buttonDefaultCover.Name = "buttonDefaultCover";
            buttonDefaultCover.UseVisualStyleBackColor = true;
            buttonDefaultCover.Click += buttonDefaultCover_Click;
            // 
            // pictureBoxThumbnail
            // 
            pictureBoxThumbnail.AllowDrop = true;
            pictureBoxThumbnail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(pictureBoxThumbnail, "pictureBoxThumbnail");
            pictureBoxThumbnail.Name = "pictureBoxThumbnail";
            pictureBoxThumbnail.TabStop = false;
            pictureBoxThumbnail.Tag = NesMenuElementBase.GameImageType.CloverThumbnail;
            pictureBoxThumbnail.DragDrop += pictureBoxArt_DragDrop;
            pictureBoxThumbnail.DragEnter += pictureBoxArt_DragEnter;
            pictureBoxThumbnail.MouseClick += pictureBoxArt_MouseClick;
            // 
            // labelSortName
            // 
            resources.ApplyResources(labelSortName, "labelSortName");
            tableLayoutPanelGameInfo.SetColumnSpan(labelSortName, 2);
            labelSortName.Name = "labelSortName";
            // 
            // textBoxSortName
            // 
            textBoxSortName.BackColor = System.Drawing.SystemColors.Window;
            tableLayoutPanelGameInfo.SetColumnSpan(textBoxSortName, 2);
            resources.ApplyResources(textBoxSortName, "textBoxSortName");
            textBoxSortName.Name = "textBoxSortName";
            textBoxSortName.TextChanged += textBoxSortName_TextChanged;
            textBoxSortName.Leave += textBoxSortName_Leave;
            // 
            // labelSaveCount
            // 
            resources.ApplyResources(labelSaveCount, "labelSaveCount");
            labelSaveCount.Name = "labelSaveCount";
            // 
            // numericUpDownSaveCount
            // 
            numericUpDownSaveCount.BackColor = System.Drawing.SystemColors.Window;
            resources.ApplyResources(numericUpDownSaveCount, "numericUpDownSaveCount");
            numericUpDownSaveCount.Name = "numericUpDownSaveCount";
            numericUpDownSaveCount.ValueChanged += numericUpDownSaveCount_ValueChanged;
            // 
            // tableLayoutPanelGameInfo
            // 
            resources.ApplyResources(tableLayoutPanelGameInfo, "tableLayoutPanelGameInfo");
            tableLayoutPanelGameInfo.Controls.Add(label10, 1, 1);
            tableLayoutPanelGameInfo.Controls.Add(panel1, 0, 22);
            tableLayoutPanelGameInfo.Controls.Add(textBoxArguments, 0, 20);
            tableLayoutPanelGameInfo.Controls.Add(labelCommandLine, 0, 19);
            tableLayoutPanelGameInfo.Controls.Add(numericUpDownSaveCount, 0, 16);
            tableLayoutPanelGameInfo.Controls.Add(maxPlayersComboBox, 0, 14);
            tableLayoutPanelGameInfo.Controls.Add(tableLayoutPanelGameID, 0, 0);
            tableLayoutPanelGameInfo.Controls.Add(tableLayoutPanelGameGenie, 0, 18);
            tableLayoutPanelGameInfo.Controls.Add(labelMaxPlayers, 0, 13);
            tableLayoutPanelGameInfo.Controls.Add(textBoxPublisher, 0, 8);
            tableLayoutPanelGameInfo.Controls.Add(labelSaveCount, 0, 15);
            tableLayoutPanelGameInfo.Controls.Add(labelGameGenie, 0, 17);
            tableLayoutPanelGameInfo.Controls.Add(textBoxSortName, 0, 6);
            tableLayoutPanelGameInfo.Controls.Add(checkBoxCompressed, 0, 2);
            tableLayoutPanelGameInfo.Controls.Add(textBoxName, 0, 4);
            tableLayoutPanelGameInfo.Controls.Add(labelCompress, 0, 1);
            tableLayoutPanelGameInfo.Controls.Add(labelPublisher, 0, 7);
            tableLayoutPanelGameInfo.Controls.Add(maskedTextBoxReleaseDate, 0, 12);
            tableLayoutPanelGameInfo.Controls.Add(labelSortName, 0, 5);
            tableLayoutPanelGameInfo.Controls.Add(labelDescription, 0, 21);
            tableLayoutPanelGameInfo.Controls.Add(labelReleaseDate, 0, 11);
            tableLayoutPanelGameInfo.Controls.Add(labelName, 0, 3);
            tableLayoutPanelGameInfo.Controls.Add(labelGenre, 1, 15);
            tableLayoutPanelGameInfo.Controls.Add(comboBoxGenre, 1, 16);
            tableLayoutPanelGameInfo.Controls.Add(labelCountry, 1, 13);
            tableLayoutPanelGameInfo.Controls.Add(comboBoxCountry, 1, 14);
            tableLayoutPanelGameInfo.Controls.Add(labelSize, 1, 2);
            tableLayoutPanelGameInfo.Controls.Add(labelCopyright, 0, 9);
            tableLayoutPanelGameInfo.Controls.Add(textBoxCopyright, 0, 10);
            tableLayoutPanelGameInfo.Name = "tableLayoutPanelGameInfo";
            // 
            // label10
            // 
            resources.ApplyResources(label10, "label10");
            label10.Name = "label10";
            // 
            // panel1
            // 
            resources.ApplyResources(panel1, "panel1");
            tableLayoutPanelGameInfo.SetColumnSpan(panel1, 2);
            panel1.Controls.Add(textBoxDescription);
            panel1.Name = "panel1";
            // 
            // textBoxDescription
            // 
            resources.ApplyResources(textBoxDescription, "textBoxDescription");
            textBoxDescription.Name = "textBoxDescription";
            textBoxDescription.TextChanged += textBoxDescription_TextChanged;
            // 
            // maxPlayersComboBox
            // 
            resources.ApplyResources(maxPlayersComboBox, "maxPlayersComboBox");
            maxPlayersComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            maxPlayersComboBox.FormattingEnabled = true;
            maxPlayersComboBox.Name = "maxPlayersComboBox";
            maxPlayersComboBox.SelectedIndexChanged += maxPlayersComboBox_SelectedIndexChanged;
            // 
            // tableLayoutPanelGameID
            // 
            resources.ApplyResources(tableLayoutPanelGameID, "tableLayoutPanelGameID");
            tableLayoutPanelGameInfo.SetColumnSpan(tableLayoutPanelGameID, 2);
            tableLayoutPanelGameID.Controls.Add(labelID, 1, 0);
            tableLayoutPanelGameID.Controls.Add(label9, 0, 0);
            tableLayoutPanelGameID.Name = "tableLayoutPanelGameID";
            // 
            // label9
            // 
            resources.ApplyResources(label9, "label9");
            label9.Name = "label9";
            // 
            // tableLayoutPanelGameGenie
            // 
            resources.ApplyResources(tableLayoutPanelGameGenie, "tableLayoutPanelGameGenie");
            tableLayoutPanelGameInfo.SetColumnSpan(tableLayoutPanelGameGenie, 2);
            tableLayoutPanelGameGenie.Controls.Add(buttonShowGameGenieDatabase, 1, 0);
            tableLayoutPanelGameGenie.Controls.Add(textBoxGameGenie, 0, 0);
            tableLayoutPanelGameGenie.Name = "tableLayoutPanelGameGenie";
            // 
            // labelCompress
            // 
            resources.ApplyResources(labelCompress, "labelCompress");
            labelCompress.Name = "labelCompress";
            // 
            // labelDescription
            // 
            resources.ApplyResources(labelDescription, "labelDescription");
            tableLayoutPanelGameInfo.SetColumnSpan(labelDescription, 2);
            labelDescription.Name = "labelDescription";
            // 
            // labelName
            // 
            resources.ApplyResources(labelName, "labelName");
            labelName.Name = "labelName";
            // 
            // labelGenre
            // 
            resources.ApplyResources(labelGenre, "labelGenre");
            labelGenre.Name = "labelGenre";
            // 
            // comboBoxGenre
            // 
            resources.ApplyResources(comboBoxGenre, "comboBoxGenre");
            comboBoxGenre.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            comboBoxGenre.FormattingEnabled = true;
            comboBoxGenre.Name = "comboBoxGenre";
            comboBoxGenre.SelectedValueChanged += comboBoxGenre_SelectedValueChanged;
            // 
            // labelCountry
            // 
            resources.ApplyResources(labelCountry, "labelCountry");
            labelCountry.Name = "labelCountry";
            // 
            // comboBoxCountry
            // 
            resources.ApplyResources(comboBoxCountry, "comboBoxCountry");
            comboBoxCountry.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            comboBoxCountry.FormattingEnabled = true;
            comboBoxCountry.Name = "comboBoxCountry";
            comboBoxCountry.SelectedValueChanged += comboBoxCountry_SelectedValueChanged;
            // 
            // labelCopyright
            // 
            resources.ApplyResources(labelCopyright, "labelCopyright");
            tableLayoutPanelGameInfo.SetColumnSpan(labelCopyright, 2);
            labelCopyright.Name = "labelCopyright";
            // 
            // textBoxCopyright
            // 
            tableLayoutPanelGameInfo.SetColumnSpan(textBoxCopyright, 2);
            resources.ApplyResources(textBoxCopyright, "textBoxCopyright");
            textBoxCopyright.Name = "textBoxCopyright";
            textBoxCopyright.TextChanged += textBoxCopyright_TextChanged;
            // 
            // tableLayoutPanelArtButtons
            // 
            resources.ApplyResources(tableLayoutPanelArtButtons, "tableLayoutPanelArtButtons");
            tableLayoutPanelArtButtons.Controls.Add(buttonGoogle, 0, 1);
            tableLayoutPanelArtButtons.Controls.Add(buttonBrowseImage, 0, 0);
            tableLayoutPanelArtButtons.Controls.Add(buttonDefaultCover, 0, 0);
            tableLayoutPanelArtButtons.Controls.Add(buttonSpine, 1, 1);
            tableLayoutPanelArtButtons.Name = "tableLayoutPanelArtButtons";
            // 
            // buttonSpine
            // 
            resources.ApplyResources(buttonSpine, "buttonSpine");
            buttonSpine.Name = "buttonSpine";
            buttonSpine.UseVisualStyleBackColor = true;
            buttonSpine.Click += buttonSpine_Click;
            // 
            // pictureBoxM2Spine
            // 
            pictureBoxM2Spine.AllowDrop = true;
            pictureBoxM2Spine.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(pictureBoxM2Spine, "pictureBoxM2Spine");
            pictureBoxM2Spine.Name = "pictureBoxM2Spine";
            pictureBoxM2Spine.TabStop = false;
            pictureBoxM2Spine.Tag = NesMenuElementBase.GameImageType.MdSpine;
            pictureBoxM2Spine.DragDrop += pictureBoxArt_DragDrop;
            pictureBoxM2Spine.DragEnter += pictureBoxArt_DragEnter;
            pictureBoxM2Spine.MouseClick += pictureBoxArt_MouseClick;
            // 
            // pictureBoxM2Front
            // 
            pictureBoxM2Front.AllowDrop = true;
            pictureBoxM2Front.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(pictureBoxM2Front, "pictureBoxM2Front");
            pictureBoxM2Front.Name = "pictureBoxM2Front";
            pictureBoxM2Front.TabStop = false;
            pictureBoxM2Front.Tag = NesMenuElementBase.GameImageType.MdFront;
            pictureBoxM2Front.DragDrop += pictureBoxArt_DragDrop;
            pictureBoxM2Front.DragEnter += pictureBoxArt_DragEnter;
            pictureBoxM2Front.MouseClick += pictureBoxArt_MouseClick;
            // 
            // structureButton
            // 
            resources.ApplyResources(structureButton, "structureButton");
            structureButton.Name = "structureButton";
            structureButton.UseVisualStyleBackColor = true;
            structureButton.Click += structureButton_Click;
            // 
            // foldersContextMenuStrip
            // 
            foldersContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { disablePagefoldersToolStripMenuItem, customToolStripMenuItem, toolStripMenuItem3, automaticToolStripMenuItem, automaticOriginalToolStripMenuItem, pagesToolStripMenuItem, pagesOriginalToolStripMenuItem, foldersToolStripMenuItem, foldersOriginalToolStripMenuItem, foldersSplitByFirstLetterToolStripMenuItem, foldersSplitByFirstLetterOriginalToolStripMenuItem, toolStripMenuItem4, maximumGamesPerFolderToolStripMenuItem, backFolderButtonPositionToolStripMenuItem, folderImagesSetToolStripMenuItem, toolStripMenuItem20, syncStructureForAllGamesCollectionsToolStripMenuItem });
            foldersContextMenuStrip.Name = "foldersContextMenuStrip";
            resources.ApplyResources(foldersContextMenuStrip, "foldersContextMenuStrip");
            // 
            // disablePagefoldersToolStripMenuItem
            // 
            disablePagefoldersToolStripMenuItem.Name = "disablePagefoldersToolStripMenuItem";
            resources.ApplyResources(disablePagefoldersToolStripMenuItem, "disablePagefoldersToolStripMenuItem");
            disablePagefoldersToolStripMenuItem.Tag = "0";
            disablePagefoldersToolStripMenuItem.Click += pagesModefoldersToolStripMenuItem_Click;
            // 
            // customToolStripMenuItem
            // 
            customToolStripMenuItem.Name = "customToolStripMenuItem";
            resources.ApplyResources(customToolStripMenuItem, "customToolStripMenuItem");
            customToolStripMenuItem.Tag = "99";
            customToolStripMenuItem.Click += pagesModefoldersToolStripMenuItem_Click;
            // 
            // toolStripMenuItem3
            // 
            toolStripMenuItem3.Name = "toolStripMenuItem3";
            resources.ApplyResources(toolStripMenuItem3, "toolStripMenuItem3");
            // 
            // automaticToolStripMenuItem
            // 
            automaticToolStripMenuItem.Checked = true;
            automaticToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            automaticToolStripMenuItem.Name = "automaticToolStripMenuItem";
            resources.ApplyResources(automaticToolStripMenuItem, "automaticToolStripMenuItem");
            automaticToolStripMenuItem.Tag = "2";
            automaticToolStripMenuItem.Click += pagesModefoldersToolStripMenuItem_Click;
            // 
            // automaticOriginalToolStripMenuItem
            // 
            automaticOriginalToolStripMenuItem.Name = "automaticOriginalToolStripMenuItem";
            resources.ApplyResources(automaticOriginalToolStripMenuItem, "automaticOriginalToolStripMenuItem");
            automaticOriginalToolStripMenuItem.Tag = "3";
            automaticOriginalToolStripMenuItem.Click += pagesModefoldersToolStripMenuItem_Click;
            // 
            // pagesToolStripMenuItem
            // 
            resources.ApplyResources(pagesToolStripMenuItem, "pagesToolStripMenuItem");
            pagesToolStripMenuItem.Name = "pagesToolStripMenuItem";
            pagesToolStripMenuItem.Tag = "4";
            pagesToolStripMenuItem.Click += pagesModefoldersToolStripMenuItem_Click;
            // 
            // pagesOriginalToolStripMenuItem
            // 
            resources.ApplyResources(pagesOriginalToolStripMenuItem, "pagesOriginalToolStripMenuItem");
            pagesOriginalToolStripMenuItem.Name = "pagesOriginalToolStripMenuItem";
            pagesOriginalToolStripMenuItem.Tag = "5";
            pagesOriginalToolStripMenuItem.Click += pagesModefoldersToolStripMenuItem_Click;
            // 
            // foldersToolStripMenuItem
            // 
            foldersToolStripMenuItem.Name = "foldersToolStripMenuItem";
            resources.ApplyResources(foldersToolStripMenuItem, "foldersToolStripMenuItem");
            foldersToolStripMenuItem.Tag = "6";
            foldersToolStripMenuItem.Click += pagesModefoldersToolStripMenuItem_Click;
            // 
            // foldersOriginalToolStripMenuItem
            // 
            foldersOriginalToolStripMenuItem.Name = "foldersOriginalToolStripMenuItem";
            resources.ApplyResources(foldersOriginalToolStripMenuItem, "foldersOriginalToolStripMenuItem");
            foldersOriginalToolStripMenuItem.Tag = "7";
            foldersOriginalToolStripMenuItem.Click += pagesModefoldersToolStripMenuItem_Click;
            // 
            // foldersSplitByFirstLetterToolStripMenuItem
            // 
            foldersSplitByFirstLetterToolStripMenuItem.Name = "foldersSplitByFirstLetterToolStripMenuItem";
            resources.ApplyResources(foldersSplitByFirstLetterToolStripMenuItem, "foldersSplitByFirstLetterToolStripMenuItem");
            foldersSplitByFirstLetterToolStripMenuItem.Tag = "8";
            foldersSplitByFirstLetterToolStripMenuItem.Click += pagesModefoldersToolStripMenuItem_Click;
            // 
            // foldersSplitByFirstLetterOriginalToolStripMenuItem
            // 
            foldersSplitByFirstLetterOriginalToolStripMenuItem.Name = "foldersSplitByFirstLetterOriginalToolStripMenuItem";
            resources.ApplyResources(foldersSplitByFirstLetterOriginalToolStripMenuItem, "foldersSplitByFirstLetterOriginalToolStripMenuItem");
            foldersSplitByFirstLetterOriginalToolStripMenuItem.Tag = "9";
            foldersSplitByFirstLetterOriginalToolStripMenuItem.Click += pagesModefoldersToolStripMenuItem_Click;
            // 
            // toolStripMenuItem4
            // 
            toolStripMenuItem4.Name = "toolStripMenuItem4";
            resources.ApplyResources(toolStripMenuItem4, "toolStripMenuItem4");
            // 
            // maximumGamesPerFolderToolStripMenuItem
            // 
            maximumGamesPerFolderToolStripMenuItem.Name = "maximumGamesPerFolderToolStripMenuItem";
            resources.ApplyResources(maximumGamesPerFolderToolStripMenuItem, "maximumGamesPerFolderToolStripMenuItem");
            // 
            // backFolderButtonPositionToolStripMenuItem
            // 
            backFolderButtonPositionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { leftmostToolStripMenuItem, rightmostToolStripMenuItem });
            backFolderButtonPositionToolStripMenuItem.Name = "backFolderButtonPositionToolStripMenuItem";
            resources.ApplyResources(backFolderButtonPositionToolStripMenuItem, "backFolderButtonPositionToolStripMenuItem");
            // 
            // leftmostToolStripMenuItem
            // 
            leftmostToolStripMenuItem.Name = "leftmostToolStripMenuItem";
            resources.ApplyResources(leftmostToolStripMenuItem, "leftmostToolStripMenuItem");
            leftmostToolStripMenuItem.Click += leftmostToolStripMenuItem_Click;
            // 
            // rightmostToolStripMenuItem
            // 
            rightmostToolStripMenuItem.Name = "rightmostToolStripMenuItem";
            resources.ApplyResources(rightmostToolStripMenuItem, "rightmostToolStripMenuItem");
            rightmostToolStripMenuItem.Click += rightmostToolStripMenuItem_Click;
            // 
            // folderImagesSetToolStripMenuItem
            // 
            folderImagesSetToolStripMenuItem.Image = Properties.Resources.folder_sm;
            folderImagesSetToolStripMenuItem.Name = "folderImagesSetToolStripMenuItem";
            resources.ApplyResources(folderImagesSetToolStripMenuItem, "folderImagesSetToolStripMenuItem");
            // 
            // toolStripMenuItem20
            // 
            toolStripMenuItem20.Name = "toolStripMenuItem20";
            resources.ApplyResources(toolStripMenuItem20, "toolStripMenuItem20");
            // 
            // syncStructureForAllGamesCollectionsToolStripMenuItem
            // 
            resources.ApplyResources(syncStructureForAllGamesCollectionsToolStripMenuItem, "syncStructureForAllGamesCollectionsToolStripMenuItem");
            syncStructureForAllGamesCollectionsToolStripMenuItem.Name = "syncStructureForAllGamesCollectionsToolStripMenuItem";
            syncStructureForAllGamesCollectionsToolStripMenuItem.Click += syncStructureForAllGamesCollectionsToolStripMenuItem_Click;
            // 
            // gamesConsoleComboBox
            // 
            gamesConsoleComboBox.BackColor = System.Drawing.SystemColors.Window;
            resources.ApplyResources(gamesConsoleComboBox, "gamesConsoleComboBox");
            gamesConsoleComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            gamesConsoleComboBox.FormattingEnabled = true;
            gamesConsoleComboBox.Name = "gamesConsoleComboBox";
            gamesConsoleComboBox.SelectedIndexChanged += gamesConsoleComboBox_SelectedIndexChanged;
            // 
            // timerUpdate
            // 
            timerUpdate.Tick += timerUpdate_Tick;
            // 
            // tableLayoutPanelMain
            // 
            resources.ApplyResources(tableLayoutPanelMain, "tableLayoutPanelMain");
            tableLayoutPanelMain.Controls.Add(groupBoxButtons, 2, 2);
            tableLayoutPanelMain.Controls.Add(groupBoxCurrentGamesCollection, 0, 0);
            tableLayoutPanelMain.Controls.Add(buttonStart, 2, 3);
            tableLayoutPanelMain.Controls.Add(groupBoxArtSega, 2, 1);
            tableLayoutPanelMain.Controls.Add(buttonExport, 1, 3);
            tableLayoutPanelMain.Controls.Add(groupBoxArtNintendo, 2, 0);
            tableLayoutPanelMain.Controls.Add(buttonAddGames, 0, 3);
            tableLayoutPanelMain.Controls.Add(groupBoxGameInfo, 1, 0);
            tableLayoutPanelMain.Controls.Add(tableLayoutPanelStatusBar, 0, 4);
            tableLayoutPanelMain.Name = "tableLayoutPanelMain";
            // 
            // groupBoxButtons
            // 
            groupBoxButtons.Controls.Add(tableLayoutPanelArtButtons);
            resources.ApplyResources(groupBoxButtons, "groupBoxButtons");
            groupBoxButtons.Name = "groupBoxButtons";
            groupBoxButtons.TabStop = false;
            // 
            // groupBoxCurrentGamesCollection
            // 
            groupBoxCurrentGamesCollection.Controls.Add(tableLayoutPanel3);
            resources.ApplyResources(groupBoxCurrentGamesCollection, "groupBoxCurrentGamesCollection");
            groupBoxCurrentGamesCollection.Name = "groupBoxCurrentGamesCollection";
            tableLayoutPanelMain.SetRowSpan(groupBoxCurrentGamesCollection, 3);
            groupBoxCurrentGamesCollection.TabStop = false;
            // 
            // tableLayoutPanel3
            // 
            resources.ApplyResources(tableLayoutPanel3, "tableLayoutPanel3");
            tableLayoutPanel3.Controls.Add(structureButton, 1, 0);
            tableLayoutPanel3.Controls.Add(gamesConsoleComboBox, 0, 0);
            tableLayoutPanel3.Controls.Add(listViewGames, 0, 1);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            // 
            // groupBoxArtSega
            // 
            groupBoxArtSega.Controls.Add(panel3);
            resources.ApplyResources(groupBoxArtSega, "groupBoxArtSega");
            groupBoxArtSega.Name = "groupBoxArtSega";
            groupBoxArtSega.TabStop = false;
            // 
            // panel3
            // 
            panel3.Controls.Add(pictureBoxM2Spine);
            panel3.Controls.Add(pictureBoxM2Front);
            resources.ApplyResources(panel3, "panel3");
            panel3.Name = "panel3";
            // 
            // groupBoxArtNintendo
            // 
            groupBoxArtNintendo.Controls.Add(panel2);
            resources.ApplyResources(groupBoxArtNintendo, "groupBoxArtNintendo");
            groupBoxArtNintendo.Name = "groupBoxArtNintendo";
            groupBoxArtNintendo.TabStop = false;
            // 
            // panel2
            // 
            panel2.Controls.Add(pictureBoxArt);
            panel2.Controls.Add(pictureBoxThumbnail);
            resources.ApplyResources(panel2, "panel2");
            panel2.Name = "panel2";
            // 
            // groupBoxGameInfo
            // 
            groupBoxGameInfo.Controls.Add(tableLayoutPanelGameInfo);
            resources.ApplyResources(groupBoxGameInfo, "groupBoxGameInfo");
            groupBoxGameInfo.Name = "groupBoxGameInfo";
            tableLayoutPanelMain.SetRowSpan(groupBoxGameInfo, 3);
            groupBoxGameInfo.TabStop = false;
            // 
            // tableLayoutPanelStatusBar
            // 
            resources.ApplyResources(tableLayoutPanelStatusBar, "tableLayoutPanelStatusBar");
            tableLayoutPanelMain.SetColumnSpan(tableLayoutPanelStatusBar, 3);
            tableLayoutPanelStatusBar.Controls.Add(toolStripStatusConnectionIcon, 0, 0);
            tableLayoutPanelStatusBar.Controls.Add(tableLayoutPanelStatusBarInner, 1, 0);
            tableLayoutPanelStatusBar.Name = "tableLayoutPanelStatusBar";
            tableLayoutPanelStatusBar.Paint += tableLayoutPanel1_Paint;
            // 
            // toolStripStatusConnectionIcon
            // 
            resources.ApplyResources(toolStripStatusConnectionIcon, "toolStripStatusConnectionIcon");
            toolStripStatusConnectionIcon.Image = Properties.Resources.red;
            toolStripStatusConnectionIcon.Name = "toolStripStatusConnectionIcon";
            toolStripStatusConnectionIcon.TabStop = false;
            // 
            // tableLayoutPanelStatusBarInner
            // 
            resources.ApplyResources(tableLayoutPanelStatusBarInner, "tableLayoutPanelStatusBarInner");
            tableLayoutPanelStatusBarInner.Controls.Add(toolStripStatusLabelShell, 0, 0);
            tableLayoutPanelStatusBarInner.Controls.Add(toolStripStatusLabelSelected, 1, 0);
            tableLayoutPanelStatusBarInner.Controls.Add(toolStripStatusLabelSize, 2, 0);
            tableLayoutPanelStatusBarInner.Controls.Add(toolStripProgressBar, 3, 0);
            tableLayoutPanelStatusBarInner.Name = "tableLayoutPanelStatusBarInner";
            // 
            // toolStripStatusLabelShell
            // 
            resources.ApplyResources(toolStripStatusLabelShell, "toolStripStatusLabelShell");
            toolStripStatusLabelShell.ForeColor = System.Drawing.SystemColors.GrayText;
            toolStripStatusLabelShell.Name = "toolStripStatusLabelShell";
            toolStripStatusLabelShell.Paint += labelBorder_Paint;
            // 
            // toolStripStatusLabelSelected
            // 
            resources.ApplyResources(toolStripStatusLabelSelected, "toolStripStatusLabelSelected");
            toolStripStatusLabelSelected.Name = "toolStripStatusLabelSelected";
            toolStripStatusLabelSelected.Paint += labelBorder_Paint;
            // 
            // toolStripStatusLabelSize
            // 
            resources.ApplyResources(toolStripStatusLabelSize, "toolStripStatusLabelSize");
            toolStripStatusLabelSize.Name = "toolStripStatusLabelSize";
            toolStripStatusLabelSize.Paint += labelBorder_Paint;
            // 
            // toolStripProgressBar
            // 
            resources.ApplyResources(toolStripProgressBar, "toolStripProgressBar");
            toolStripProgressBar.Name = "toolStripProgressBar";
            toolStripProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            // 
            // label1
            // 
            resources.ApplyResources(label1, "label1");
            label1.ForeColor = System.Drawing.SystemColors.GrayText;
            label1.Name = "label1";
            label1.Paint += labelBorder_Paint;
            // 
            // label2
            // 
            resources.ApplyResources(label2, "label2");
            label2.Name = "label2";
            label2.Paint += labelBorder_Paint;
            // 
            // label3
            // 
            resources.ApplyResources(label3, "label3");
            label3.Name = "label3";
            label3.Paint += labelBorder_Paint;
            // 
            // progressBar1
            // 
            resources.ApplyResources(progressBar1, "progressBar1");
            progressBar1.Name = "progressBar1";
            // 
            // MainForm
            // 
            AllowDrop = true;
            resources.ApplyResources(this, "$this");
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(tableLayoutPanelMain);
            Controls.Add(menuStrip);
            Icon = Properties.Resources.icon;
            KeyPreview = true;
            Name = "MainForm";
            FormClosing += MainForm_FormClosing;
            Load += MainForm_Load;
            Shown += MainForm_Shown;
            DragDrop += dragDrop;
            DragEnter += dragEnter;
            KeyDown += MainForm_KeyDown;
            menuStrip.ResumeLayout(false);
            menuStrip.PerformLayout();
            contextMenuStrip.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBoxArt).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxThumbnail).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownSaveCount).EndInit();
            tableLayoutPanelGameInfo.ResumeLayout(false);
            tableLayoutPanelGameInfo.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            tableLayoutPanelGameID.ResumeLayout(false);
            tableLayoutPanelGameID.PerformLayout();
            tableLayoutPanelGameGenie.ResumeLayout(false);
            tableLayoutPanelGameGenie.PerformLayout();
            tableLayoutPanelArtButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBoxM2Spine).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxM2Front).EndInit();
            foldersContextMenuStrip.ResumeLayout(false);
            tableLayoutPanelMain.ResumeLayout(false);
            groupBoxButtons.ResumeLayout(false);
            groupBoxCurrentGamesCollection.ResumeLayout(false);
            tableLayoutPanel3.ResumeLayout(false);
            groupBoxArtSega.ResumeLayout(false);
            panel3.ResumeLayout(false);
            groupBoxArtNintendo.ResumeLayout(false);
            panel2.ResumeLayout(false);
            groupBoxGameInfo.ResumeLayout(false);
            tableLayoutPanelStatusBar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)toolStripStatusConnectionIcon).EndInit();
            tableLayoutPanelStatusBarInner.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addMoreGamesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.Button buttonAddGames;
        private System.Windows.Forms.OpenFileDialog openFileDialogNes;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.OpenFileDialog openFileDialogImage;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.ToolStripMenuItem kernelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem flashCustomKernelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.Timer timerCalculateGames;
        private System.Windows.Forms.ToolStripMenuItem uninstallToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fAQToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gitHubPageWithActualReleasesToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem presetsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addPresetToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deletePresetToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem searchToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem epilepsyProtectionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cloverconHackToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem resetUsingCombinationOfButtonsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem selectButtonCombinationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem enableAutofireToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem globalCommandLineArgumentsexpertsOnluToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem upABStartOnSecondControllerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modulesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem installModulesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem uninstallModulesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem synchronizeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem useXYOnClassicControllerAsAutofireABToolStripMenuItem;
        private System.Windows.Forms.Timer timerConnectionCheck;
        private System.Windows.Forms.ToolStripMenuItem saveSettingsToNESMiniNowToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveStateManagerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openFTPInExplorerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openTelnetToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem languageToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem8;
        private System.Windows.Forms.ToolStripMenuItem takeScreenshotToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog saveDumpFileDialog;
        private System.Windows.Forms.OpenFileDialog openDumpFileDialog;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem11;
        private System.Windows.Forms.ToolStripMenuItem compressGamesToolStripMenuItem;
        internal System.Windows.Forms.ListView listViewGames;
        private System.Windows.Forms.ColumnHeader gameName;
        private System.Windows.Forms.ToolStripMenuItem compressSelectedGamesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteSelectedGamesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem decompressSelectedGamesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem downloadBoxArtForSelectedGamesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem donateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem compressBoxArtToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteSelectedGamesBoxArtToolStripMenuItem;
        private System.Windows.Forms.Timer timerShowSelected;
        private System.Windows.Forms.ToolStripMenuItem reloadGamesToolStripMenuItem;
        private System.Windows.Forms.Button buttonExport;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem13;
        private System.Windows.Forms.ToolStripMenuItem exportGamesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem explorerToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem14;
        private System.Windows.Forms.ToolStripMenuItem scanForNewBoxArtForSelectedGamesToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem15;
        private System.Windows.Forms.ToolStripMenuItem disableHakchi2PopupsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem16;
        private System.Windows.Forms.ToolStripMenuItem resetOriginalGamesToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem12;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem originalGamesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem positionAtTheTopToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem positionAtTheBottomToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem positionSortedToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem separateGamesForMultibootToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sFROMToolToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem enableSFROMToolToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem flashUbootToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem normalModeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sDModeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem advancedToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem membootOriginalKernelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem membootRecoveryKernelToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem10;
        private System.Windows.Forms.ToolStripMenuItem dumpTheWholeNANDToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolFlashTheWholeNANDStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dumpNANDBToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dumpNANDCPartitionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem flashNANDCPartitionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem resetToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem usePCMPatchWhenAvailableToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sFROMToolToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem editROMHeaderToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem9;
        private System.Windows.Forms.ToolStripMenuItem resetROMHeaderToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem17;
        private System.Windows.Forms.Label labelID;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.Label labelPublisher;
        private System.Windows.Forms.TextBox textBoxPublisher;
        private System.Windows.Forms.Label labelCommandLine;
        private System.Windows.Forms.TextBox textBoxArguments;
        private System.Windows.Forms.PictureBox pictureBoxArt;
        private System.Windows.Forms.Button buttonBrowseImage;
        private System.Windows.Forms.Button buttonGoogle;
        private System.Windows.Forms.Label labelMaxPlayers;
        private System.Windows.Forms.Label labelGameGenie;
        private System.Windows.Forms.TextBox textBoxGameGenie;
        private System.Windows.Forms.Label labelReleaseDate;
        private System.Windows.Forms.MaskedTextBox maskedTextBoxReleaseDate;
        private System.Windows.Forms.Button buttonShowGameGenieDatabase;
        private System.Windows.Forms.CheckBox checkBoxCompressed;
        private System.Windows.Forms.Label labelSize;
        private System.Windows.Forms.Button buttonDefaultCover;
        private System.Windows.Forms.PictureBox pictureBoxThumbnail;
        private System.Windows.Forms.Label labelSortName;
        private System.Windows.Forms.TextBox textBoxSortName;
        private System.Windows.Forms.Label labelSaveCount;
        private System.Windows.Forms.NumericUpDown numericUpDownSaveCount;
        private System.Windows.Forms.ToolStripMenuItem centerBoxArtThumbnailToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem positionHiddenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem selectEmulationCoreToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addCustomAppToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem useLinkedSyncToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bootImageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem changeBootImageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem disableBootImageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem resetDefaultBootImageToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem18;
        private System.Windows.Forms.ToolStripMenuItem prepareArtDirectoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem formatNANDCToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem5;
        private System.Windows.Forms.Button structureButton;
        private System.Windows.Forms.ContextMenuStrip foldersContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem disablePagefoldersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem customToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem automaticToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem automaticOriginalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pagesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pagesOriginalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem foldersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem foldersOriginalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem foldersSplitByFirstLetterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem foldersSplitByFirstLetterOriginalToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem maximumGamesPerFolderToolStripMenuItem;
        private System.Windows.Forms.ComboBox gamesConsoleComboBox;
        private System.Windows.Forms.ToolStripMenuItem kachikachiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem canoeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem retroarchToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem flashNANDBPartitionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sortByToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem coreToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem systemToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showGamesWithoutBoxArtToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem developerToolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem devForceSshToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem19;
        private System.Windows.Forms.ToolStripMenuItem repairGamesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem membootCustomKernelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem uploadTotmpforTestingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem folderImagesSetToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem factoryResetToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rebootToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem backFolderButtonPositionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem leftmostToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rightmostToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem20;
        private System.Windows.Forms.ToolStripMenuItem syncStructureForAllGamesCollectionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator modRepoStartSeparator;
        private System.Windows.Forms.ToolStripMenuItem messageOfTheDayToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem22;
        private System.Windows.Forms.ToolStripMenuItem forceClovershellMembootsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem23;
        private System.Windows.Forms.ToolStripMenuItem technicalInformationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dumpOriginalKernellegacyToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem24;
        private System.Windows.Forms.Timer timerUpdate;
        private System.Windows.Forms.ToolStripMenuItem forceNetworkMembootsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem alwaysCopyOriginalGamesToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem25;
        private System.Windows.Forms.ToolStripMenuItem convertSNESROMSToSFROMToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem separateGamesStorageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem autodetectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem asIsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem switchRunningFirmwareToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem6;
        private System.Windows.Forms.ToolStripMenuItem generateModulesReportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem archiveSelectedGamesToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator modRepoEndSeparator;
        private System.Windows.Forms.ToolStripMenuItem manageModRepositoriesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveDmesgOutputToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem joinOurDiscordServerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rRockinTheClassicsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem formatSDCardToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem downloadLatestHakchiToolStripMenuItem;
        private com.clusterrr.hakchi_gui.Wireless.Bluetooth.BluetoothMenuItem bluetoothToolStripMenuItem;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelGameGenie;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label labelCompress;
        private System.Windows.Forms.ComboBox maxPlayersComboBox;
        private System.Windows.Forms.PictureBox pictureBoxM2Spine;
        private System.Windows.Forms.PictureBox pictureBoxM2Front;
        private System.Windows.Forms.TextBox textBoxDescription;
        private System.Windows.Forms.Label labelDescription;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelGameInfo;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelGameID;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelArtButtons;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.Button buttonSpine;
        private System.Windows.Forms.Label labelGenre;
        private System.Windows.Forms.ComboBox comboBoxGenre;
        private System.Windows.Forms.Label labelCountry;
        private System.Windows.Forms.ComboBox comboBoxCountry;
        private System.Windows.Forms.ToolStripMenuItem segaUiThemeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem autoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem unitedStatesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem europeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem japanToolStripMenuItem;
        private System.Windows.Forms.TextBox textBoxCopyright;
        private System.Windows.Forms.Label labelCopyright;
        private System.Windows.Forms.ToolStripMenuItem scrapeSelectedGamesToolStripMenuItem;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelMain;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.GroupBox groupBoxArtSega;
        private System.Windows.Forms.GroupBox groupBoxArtNintendo;
        private System.Windows.Forms.GroupBox groupBoxGameInfo;
        private System.Windows.Forms.GroupBox groupBoxCurrentGamesCollection;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelStatusBar;
        private System.Windows.Forms.PictureBox toolStripStatusConnectionIcon;
        private System.Windows.Forms.Label toolStripStatusLabelShell;
        private System.Windows.Forms.Label toolStripStatusLabelSelected;
        private System.Windows.Forms.Label toolStripStatusLabelSize;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ProgressBar toolStripProgressBar;
        private System.Windows.Forms.ProgressBar progressBar1;
        // tableLayoutPanel1 was a leftover designer field that was never instantiated or referenced.
        // Removed to silence CS0169. If you re-add this control in the WinForms designer, it will be re-declared.
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelStatusBarInner;
        private System.Windows.Forms.GroupBox groupBoxButtons;
        private System.Windows.Forms.ToolStripMenuItem addPrefixToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removePrefixToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem enableInformationScrapeOnImportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importGamesFromMiniToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem regionToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem setRegionToolStripMenuItem;
    }
}

