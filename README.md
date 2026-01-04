# PDF Stamper Application

A WPF desktop application for adding custom image stamps/watermarks to PDF documents.

## Features
- 📄 **Multi-format support** - Works with PDF, PNG, JPG, JPEG
- 🎛️ **Real-time controls** - Adjust stamp size, X/Y position with sliders
- 🔄 **Batch processing** - Applies stamp to all pages automatically
- 💾 **Non-destructive** - Creates new stamped files, preserves originals
- 📱 **User-friendly UI** - Intuitive WPF interface with clear feedback

## Technologies
- **Frontend:** WPF, XAML, MVVM Pattern
- **Backend:** C#, .NET Framework
- **PDF Library:** iText7
- **Tools:** Visual Studio, Git

## How It Works
1. Select input PDF and stamp image
2. Adjust position and size using interactive sliders
3. Click "Stamp PDF" to generate watermarked document
4. New file saved as `Stamped_[OriginalName].pdf`

## Use Cases
- Company branding on documents
- Confidential/Draft watermarks
- Digital signature placement
- Copyright protection
