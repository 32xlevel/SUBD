using System;
using System.Collections.Generic;
using ClosedXML.Excel;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;

namespace SUBD
{
    public static class Reports
    {
        public static void WriteExcel(string file, List<List<string>> data, string sheetName = "SQL query report")
        {
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add(sheetName);

                for (int i = 0; i < data.Count; i++)
                {
                    for (int j = 0; j < data[i].Count; j++)
                    {
                        worksheet.Row(i + 1).Cell(j + 1).Value = data[i][j];
                    }
                }

                workbook.SaveAs(file);
            }
        }

        public static void WriteWord(string file, List<List<string>> data)
        {
            try
            {
                CreateWordprocessingDocument(file);
            }
            catch
            {
                Console.WriteLine("ALREADY EXISTS");
            }

            CreateTable(file, data);
        }

        private static void CreateTable(string fileName, List<List<string>> data)
        {
            using (var document = WordprocessingDocument.Open(fileName, true))
            {
                var table = new DocumentFormat.OpenXml.Wordprocessing.Table();

                var tableProperties = new TableProperties(
                    new TableBorders(
                        new TopBorder
                        {
                            Val =
                                new EnumValue<BorderValues>(BorderValues.Single),
                            Size = 3
                        },
                        new BottomBorder()
                        {
                            Val =
                                new EnumValue<BorderValues>(BorderValues.Single),
                            Size = 3
                        },
                        new LeftBorder()
                        {
                            Val =
                                new EnumValue<BorderValues>(BorderValues.Single),
                            Size = 3
                        },
                        new RightBorder()
                        {
                            Val =
                                new EnumValue<BorderValues>(BorderValues.Single),
                            Size = 3
                        },
                        new InsideHorizontalBorder()
                        {
                            Val =
                                new EnumValue<BorderValues>(BorderValues.Single),
                            Size = 3
                        },
                        new InsideVerticalBorder()
                        {
                            Val =
                                new EnumValue<BorderValues>(BorderValues.Single),
                            Size = 3
                        }
                    )
                );

                table.AppendChild(tableProperties);

                for (int i = 0; i < data.Count; i++)
                {
                    TableRow tableRow = new TableRow();

                    for (int j = 0; j < data[i].Count; j++)
                    {
                        TableCell tableCell = new TableCell();
                        var tablePropertiesTemp = new TableCellProperties(new TableCellWidth
                            {Type = TableWidthUnitValues.Dxa, Width = "1400"});
                        var paragraph = new Paragraph(new Run(new Text(data[i][j])));

                        tableCell.Append(tablePropertiesTemp);
                        tableCell.Append(paragraph);
                        tableRow.Append(tableCell);
                    }

                    table.Append(tableRow);
                }

                document.MainDocumentPart.Document.Body.Append(table);
            }
        }

        private static void CreateWordprocessingDocument(string filepath)
        {
            using (var wordDocument = WordprocessingDocument.Create(filepath, WordprocessingDocumentType.Document))
            {
                MainDocumentPart mainPart = wordDocument.AddMainDocumentPart();

                mainPart.Document = new Document();
                mainPart.Document.AppendChild(new Body());
            }
        }
    }
}