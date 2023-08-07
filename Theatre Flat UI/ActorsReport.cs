using DevExpress.XtraPrinting;
using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;

namespace Practice
{
    public partial class ActorsReport : DevExpress.XtraReports.UI.XtraReport
    {
        public ActorsReport()
        {
            InitializeComponent();
        }

        private void ActorsReport_Load(object sender, EventArgs e)
        {
            // Create a report.
            XtraReport report = new XtraReport()
            {
                Name = "Report Example",
                Bands = {
                    new DetailBand() {
                        Controls = {
                            new XRLabel() {
                                Text = "Some content goes here...",
                            }
                        }
                    }
                }
            };

            // Specify export options.
            PdfExportOptions pdfExportOptions = new PdfExportOptions()
            {
                PdfACompatibility = PdfACompatibility.PdfA1b
            };

            // Specify the path for the exported PDF file.  
            string pdfExportFile =
                Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) +
                @"\Downloads\" +
                report.Name +
                ".pdf";

            // Export the report.
            report.ExportToPdf(pdfExportFile, pdfExportOptions);
        }
    }
}