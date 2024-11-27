# TelerikPdfViewerRenderBugMinimalRepo

This repository contains a minimal reproducible example demonstrating an issue with Telerik's `RadPdfViewer`.

## Overview

The repository includes two projects:
1. **WPF App (.NET 8)**  
2. **WPF App (.NET Framework 4.8)**  

Both projects exhibit the same problem.

## Problem Description

The `RadPdfViewer` element does not render PDF documents correctly when the executing thread's culture is set to a culture that uses a comma (`','`) as the decimal separator.

### Note on Telerik Version

This issue occurs after updating the Telerik NuGet package to the following version:  
**`Telerik.Windows.Controls.FixedDocumentViewers.for.Wpf.Xaml.2024.4.1111`**

## Additional Notes

- This repository is derived from our production code. 
- The .NET 8 application includes additional code we use for generating reports. This functionality appears to work without issues and is included for completeness.
- The included setup for `RadPdfViewer` mirrors our production environment. However, code-behind logic for toolbar actions is not implemented here, as it is not required to reproduce the issue.

## Steps to Reproduce

1. Open either project.
2. In `App.xaml.cs`, locate the constructor of the `App` class. 
   - Two lines of code are provided to set the culture:
     - `CultureInfo("hr-HR")` (uses a comma as a decimal separator).  
     - `CultureInfo("en-US")` (uses a dot as a decimal separator).  
   - Uncomment the desired culture line for testing.
3. Run the application.
4. Observe the PDF document that loads automatically.  
   - Optionally, use the provided functionality to load your own PDF document for further testing.
5. Observe the rendering behavior.

## Expected Behavior

The `RadPdfViewer` should render the PDF document correctly, irrespective of the culture setting.
