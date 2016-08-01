; Script generated by the Inno Setup Script Wizard.
; SEE THE DOCUMENTATION FOR DETAILS ON CREATING INNO SETUP SCRIPT FILES!

#define MyAppName "Spellpad"
#define MyAppVersion "0.9.35"
#define MyAppPublisher "Ahmed.C"
#define MyAppURL "https://cdemha.github.io/Spellpad"
#define MyAppExeName "Spellpad.exe"

[Setup]
; NOTE: The value of AppId uniquely identifies this application.
; Do not use the same AppId value in installers for other applications.
; (To generate a new GUID, click Tools | Generate GUID inside the IDE.)
AppId={{245AB36C-2693-4C89-B16B-A848A3A5540F}
AppName={#MyAppName}
AppVersion={#MyAppVersion}
;AppVerName={#MyAppName} {#MyAppVersion}
AppPublisher={#MyAppPublisher}
AppPublisherURL={#MyAppURL}
AppSupportURL={#MyAppURL}
AppUpdatesURL={#MyAppURL}
DefaultDirName={pf}\{#MyAppName}
DefaultGroupName={#MyAppName}
AllowNoIcons=yes
OutputBaseFilename=setup
Compression=lzma
SolidCompression=yes

[Languages]
Name: "english"; MessagesFile: "compiler:Default.isl"

[Tasks]
Name: "desktopicon"; Description: "{cm:CreateDesktopIcon}"; GroupDescription: "{cm:AdditionalIcons}"; Flags: unchecked

[Files]
Source: "C:\Users\Ahmed\Dropbox\Programming\Desktop\Visual Studio Projects\Current\Spellpad\Spellpad\Source\Spellpad\Spellpad\bin\Debug\Spellpad.exe"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\Ahmed\Dropbox\Programming\Desktop\Visual Studio Projects\Current\Spellpad\Spellpad\Source\Spellpad\Spellpad\bin\Debug\AppLimit.CloudComputing.SharpBox.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\Ahmed\Dropbox\Programming\Desktop\Visual Studio Projects\Current\Spellpad\Spellpad\Source\Spellpad\Spellpad\bin\Debug\Ionic.Zip.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\Ahmed\Dropbox\Programming\Desktop\Visual Studio Projects\Current\Spellpad\Spellpad\Source\Spellpad\Spellpad\bin\Debug\MessageBoxManager.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\Ahmed\Dropbox\Programming\Desktop\Visual Studio Projects\Current\Spellpad\Spellpad\Source\Spellpad\Spellpad\bin\Debug\Microsoft.VisualStudio.QualityTools.UnitTestFramework.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\Ahmed\Dropbox\Programming\Desktop\Visual Studio Projects\Current\Spellpad\Spellpad\Source\Spellpad\Spellpad\bin\Debug\Newtonsoft.Json.Net40.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\Ahmed\Dropbox\Programming\Desktop\Visual Studio Projects\Current\Spellpad\Spellpad\Source\Spellpad\Spellpad\bin\Debug\Spellpad.exe"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\Ahmed\Dropbox\Programming\Desktop\Visual Studio Projects\Current\Spellpad\Spellpad\Source\Spellpad\Spellpad\bin\Debug\Spellpad.exe.config"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\Ahmed\Dropbox\Programming\Desktop\Visual Studio Projects\Current\Spellpad\Spellpad\Source\Spellpad\Spellpad\bin\Debug\Spellpad.pdb"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\Ahmed\Dropbox\Programming\Desktop\Visual Studio Projects\Current\Spellpad\Spellpad\Source\Spellpad\Spellpad\bin\Debug\Spellpad.vshost.exe"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\Ahmed\Dropbox\Programming\Desktop\Visual Studio Projects\Current\Spellpad\Spellpad\Source\Spellpad\Spellpad\bin\Debug\Spellpad.vshost.exe.config"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\Ahmed\Dropbox\Programming\Desktop\Visual Studio Projects\Current\Spellpad\Spellpad\Source\Spellpad\Spellpad\bin\Debug\Spellpad.vshost.exe.manifest"; DestDir: "{app}"; Flags: ignoreversion
; NOTE: Don't use "Flags: ignoreversion" on any shared system files

[Registry]
Root: HKLM; Subkey: "Software\Microsoft\Windows\CurrentVersion\App Paths\{#MyAppName}.exe"; ValueType: string; ValueName: ""; ValueData: "{app}\Spellpad.exe"; Flags: uninsdeletekey
Root: HKLM; Subkey: "Software\Wow6432Node\{#MyAppName}"; ValueType: string; ValueName: ""; ValueData: "{app}\Spellpad.exe"; Flags: uninsdeletekey 

[Icons]
Name: "{group}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"
Name: "{commondesktop}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"; Tasks: desktopicon

[Run]
Filename: "{app}\{#MyAppExeName}"; Description: "{cm:LaunchProgram,{#StringChange(MyAppName, '&', '&&')}}"; Flags: nowait postinstall skipifsilent
