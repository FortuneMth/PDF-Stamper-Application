using System;
using System.Windows;
using Microsoft.Win32;
using iText.IO.Image;
using iText.Kernel.Pdf;
using iText.Kernel.Geom;
using iText.Kernel.Pdf.Canvas;

namespace Stamp_App
{
    public partial class MainWindow : Window
    {
        private string selectedPdfPath;
        private string selectedImagePath;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void SelectPdf_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog
            {
                Filter = "PDF Files (*.pdf)|*.pdf"
            };

            if (dialog.ShowDialog() == true)
            {
                selectedPdfPath = dialog.FileName;
                PdfPathText.Text = selectedPdfPath;
            }
        }

        private void SelectImage_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog
            {
                Filter = "Image Files (*.png;*.jpg;*.jpeg)|*.png;*.jpg;*.jpeg"
            };

            if (dialog.ShowDialog() == true)
            {
                selectedImagePath = dialog.FileName;
                ImagePathText.Text = selectedImagePath;
            }
        }

       
        private void Stamp_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(selectedPdfPath) || string.IsNullOrEmpty(selectedImagePath))
            {
                MessageBox.Show("Please select both a PDF and a stamp image.");
                return;
            }

            try
            {
                float size = (float)SizeSlider.Value;
                float x = (float)XSlider.Value;
                float y = (float)YSlider.Value;

                string outputPdf = System.IO.Path.Combine(
                    System.IO.Path.GetDirectoryName(selectedPdfPath),
                    "Stamped_" + System.IO.Path.GetFileName(selectedPdfPath)
                );

                StampPdf(
                    selectedPdfPath,
                    outputPdf,
                    selectedImagePath,
                    x,
                    y,
                    size,
                    size
                );

                MessageBox.Show("PDF stamped successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }


        private void StampPdf(
            string inputPdf,
            string outputPdf,
            string imagePath,
            float x,
            float y,
            float width,
            float height)
        {
            PdfReader reader = new PdfReader(inputPdf);
            PdfWriter writer = new PdfWriter(outputPdf);
            PdfDocument pdfDoc = new PdfDocument(reader, writer);

            ImageData imageData = ImageDataFactory.Create(imagePath);

            for (int i = 1; i <= pdfDoc.GetNumberOfPages(); i++)
            {
                PdfPage page = pdfDoc.GetPage(i);
                PdfCanvas canvas = new PdfCanvas(page);

                Rectangle rect = new Rectangle(x, y, width, height);
                canvas.AddImageFittedIntoRectangle(imageData, rect, false);
            }

            pdfDoc.Close();
        }
    }
}
