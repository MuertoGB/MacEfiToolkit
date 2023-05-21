<h1 align="center">
<img width="200" src="files/images/img128px.png" alt="SMCFT Logo">
<br>
Mac EFI Toolkit
</h1>

<h4 align="center">A tool for repairing and modifying data in Mac EFI binaries. </h4>

<p align="center">
  <a href="#about">About</a> •
  <a href="#features">Features</a> •
  <a href="#download">Download</a> •
  <a href="#requirements">Requirements</a> •
  <a href="#acknowledgements">Acknowledgements</a> •
  <a href="#donate">Donate</a>
</p>

## About

>🛠 Current Status: Working on database implementation.

Mac EFI Toolkit is a firmware repair tool designed to aid technicians in repair of a Mac EFIROM (BIOS).

This application is currently under development, it is by no means complete, fully functional, or final. There is much more to complete; however functionality such as viewing ROM information, dumping the Fsys region, and repairing the Fsys crc32 is working. It has been uploaded per request, now anyone interested can get involved and ask questions.

<img width="550" src="files/images/met.png" alt="MET">
<img width="550" src="files/images/met_alt.png" alt="MET_ALT">

## Features

| Suggested features                                         | Status      |
|------------------------------------------------------------|-------------|
| Knuth–Morris–Pratt algorithm for searching binary offsets  |🟢 Completed |
| Ability to detect APFSJumpStart DXE                        |🟢 Completed |
| Check serial number with EveryMac							 |🟢 Completed |
| View FITC and ME version						             |🟢 Completed |
| Detect and fix invalid Fsys checksums                      |🟢 Completed |
| Move from server to database for fetching config code      |🟢 Completed |
| View ROM information                                       |🟡 Partially Completed |
| Dump and replace Fsys block                                |🟡 Partially Completed |
| Replace serial with automatic HWC and CRC32 calculation    |🟡 Partially Completed |
| Clear NVRAM and EFI lock with header preservation          |🟠 Not Started |
| Detect MDM status in the NVRAM                             |🔴 Undecided |
| Detect email address in the NVRAM                          |🔴 Undecided |
| Configure ME region	                                     |🔴 Undecided |

When the editing features are implemented, original files will be left untouched. The new binary will be built from a copy in memory.

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
|[0.5.2](https://github.com/MuertoGB/MacEfiToolkit/releases/tag/052)| 21st May 2023 | Yes | BETA |
|[0.5.1](https://github.com/MuertoGB/MacEfiToolkit/releases/tag/051)| 15th May 2023 | No | BETA |

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

All donations go back into improving my tools and workspace.

<a href="https://www.paypal.com/donate/?hosted_button_id=Z88F3UEZB47SQ"><img width="160" src="https://www.paypalobjects.com/webstatic/mktg/Logo/pp-logo-200px.png" alt="PayPal Logo" vspace="5" hspace="5"></a>
