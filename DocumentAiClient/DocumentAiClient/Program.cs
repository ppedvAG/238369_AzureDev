// See https://aka.ms/new-console-template for more information
using Azure;
using Azure.AI.FormRecognizer;
using Azure.AI.FormRecognizer.DocumentAnalysis;

Console.WriteLine("Hello, World!");

var endPoint = "https://mydocaaaaaaa.cognitiveservices.azure.com/";
var key = "a9e8644a3f974d30a910f70087bacfc9";

FormRecognizerClient client = new FormRecognizerClient(new Uri(endPoint), new AzureKeyCredential(key));

var docClient = new DocumentAnalysisClient(new Uri(endPoint), new AzureKeyCredential(key));

var docPath = @"C:\Users\Fred\Desktop\HolzRECHNUNG7\HolzRECHNUNG7.pdf";
var result = docClient.AnalyzeDocument(WaitUntil.Completed, "cccc", File.OpenRead(docPath));

var summe = result.Value.Documents.First().Fields["Summe"].Content;
var re = result.Value.Documents.First().Fields["Rechnungsempfaenger"].Content;

Console.WriteLine(summe);
Console.WriteLine(re);
