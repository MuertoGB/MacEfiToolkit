<h1 align="center">
<img width="200" src="files/images/img128px.png" alt="SMCFT Logo">
<br>
Mac EFI Toolkit
</h1>

<h4 align="center">A tool for viewing and repairing data in Mac EFI binaries</h4>
<p align="center">
  <a href="#about">About</a> •
  <a href="#features">Features</a> •
  <a href="#download">Download</a> •
  <a href="#requirements">Requirements</a> •
  <a href="#acknowledgements">Acknowledgements</a> •
  <a href="#donate">Donate</a>
</p>

## About

This application is in active development, it is currently unfinished.
>🛠 Current Status: Working on finishing the editor.

Mac EFI Toolkit, or 'mefit' is a firmware repair and information gathering tool designed to aid technicians in repair of a Mac EFIROM firmware (BIOS), which consists of the following features:-

<img width="550" src="files/images/met.png" alt="MET">
<img width="550" src="files/images/met_alt.png" alt="MET_ALT">

## Features

- [x] Implement Knuth–Morris–Pratt algorithm for searching binary data
- [x] Add option to export and store Fsys regions
- [ ] Replace the Fsys block
- [ ] Clear NVRAM (SVS, VSS) with section header preservation
- [ ] Add option to replace serial number
> The editor is in active development
- [x] Ability to detect if the firmware is APFS capable
- [x] Detect and fix invalid Fsys crc32 checksums
- [x] Validate binary size
- [x] View specific ROM information, including the FITC and ME version
- [x] Check serial number with EveryMac
- [x] HWC decoding that can reference a local database or fall back to Apples server
- [x] Original binaries left untouched
- [ ] Complete the logging systems

 

| SUGGESTED FEATURES                   | Status      |
|--------------------------------------|-------------|
| Detect MDM status                    |🔴 Undecided |
| Detect email address in the NVRAM    |🔴 Undecided |
| Configure ME region	               |🔴 Undecided |

**Implemented application features:**
```
- Automatic handling of uncaught errors
- Drag and drop support for .bin files
- No installation necessary
- DPI scaling support
- Integrity checking
- Memory Management
- Version checking
```

Plus more, only time will tell.

## Download

| Version| Release Date| Latest | Channel |
|--------|-------------|--------|---------|
|[0.6.0](https://github.com/MuertoGB/MacEfiToolkit/releases/latest)| Not Set | Yes | BETA |

> 📋 View the full changelog [here](CHANGELOG.md)

## Requirements

**Application:**
- MS [.NET Framework 4.5](https://www.microsoft.com/en-GB/download/details.aspx?id=30653)
- Windows 7, 8, 8.1, 10. 32, or 64-bit
- Internet connectivity required for:-
> - Version Checking (Can be disabled in settings).
> - Fetching model data from the server when not present in the database.

**Build requirements:**
- Visual Studio 2019 or higher

Open `mefit.sln` in Visual Studio, you'll then need to either disable signing, sign the application yourself by creating a new personal information exchange cert (.pfx), or disable the signature check, otherwise the application will show an invalid signature error.

- From the Visual Studio menu, click "Project > mefit Properties > Signing".
- Either uncheck `Sign the assembly`, then comment out the code below, or...
- Create a new .pfx, then sign the assembly, or...
- Ignore everything above and just comment out the code below to skip validation.

**mefit/Program.vb (main() entry point):**
```cs
// Verify integrity of application to ensure it's not corrupt.
if (!AssemblyVerifier.VerifyAssemblyStrongNameSignature(strAppName))
{
	MessageBox.Show("The assembly signature is invalid, or cannot be verified!\r\nYou should discard of, and reacquire the file.",
                    "Signature Verification", MessageBoxButtons.OK, MessageBoxIcon.Error);
}
```

## Acknowledgements

#### This software uses the following third party libraries, or resources:-

LZMA [v22.01 SDK](https://www.7-zip.org/sdk.html), by Igor Pavlov.\
The [Knuth-Morris-Pratt algorithm](https://en.wikipedia.org/wiki/Knuth%E2%80%93Morris%E2%80%93Pratt_algorithm), by Donald Knuth, James H. Morris, and  Vaughan Pratt.\
[MacModelShelf](https://github.com/MagerValp/MacModelShelf) database, by MagerValp.\
Application icon by [Creatype](https://www.flaticon.com/free-icon/toolkit_6457096?term=toolkit&page=1&position=38&origin=search&related_id=6457096) on [Flaticon](https://www.flaticon.com).

## Donate

All donations go back into improving my software and workspace.

<a href="https://www.paypal.com/donate/?hosted_button_id=Z88F3UEZB47SQ"><img width="160" src="https://www.paypalobjects.com/webstatic/mktg/Logo/pp-logo-200px.png" alt="PayPal Logo" vspace="5" hspace="5"></a>
