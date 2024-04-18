using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using BoldReports.Web.ReportViewer;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Caching.Memory;

namespace SyncfusionDocumentation_Personal.Controllers;

[Route("api/{controller}/{action}/{id?}")]
[ApiController]
public class BoldReportsAPIController : ControllerBase, IReportController
{
    // Report viewer requires a memory cache to store the information of consecutive client requests and
    // the rendered report viewer in the server.
    private IMemoryCache _cache;


    //IHostingEnvironment used with sample to get the application data from wwwroot.
    private IWebHostEnvironment _hostingEnvironment;

    public BoldReportsAPIController(IMemoryCache memoryCache, IWebHostEnvironment hostingEnvironment)
    {
        _cache = memoryCache;
        _hostingEnvironment = hostingEnvironment;
    }

    [ActionName("GetResource")]
    [AcceptVerbs("GET")]
    // Method will be called from Report Viewer client to get the image src for Image report item.
    public object GetResource(ReportResource resource)
    {
        return ReportHelper.GetResource(resource, this, _cache);
    }

    // Method will be called to initialize the report information to load the report with ReportHelper for processing.
    [NonAction]
    public void OnInitReportOptions(ReportViewerOptions reportOption)
    {
        string basePath = Path.Combine(_hostingEnvironment.WebRootPath, "resources");
        string reportPath = Path.Combine(basePath, reportOption.ReportModel.ReportPath);

        // Here, we have loaded the sales-order-detail.rdl report from the application folder wwwroot\Resources. sales-order-detail.rdl should be in the wwwroot\Resources application folder.
        FileStream fileStream = new FileStream(reportPath, System.IO.FileMode.Open, System.IO.FileAccess.Read);
        MemoryStream reportStream = new MemoryStream();
        fileStream.CopyTo(reportStream);
        reportStream.Position = 0;
        fileStream.Close();
        reportOption.ReportModel.Stream = reportStream;
    
    }

    // Method will be called when report is loaded internally to start the layout process with ReportHelper.
    [NonAction]
    public void OnReportLoaded(ReportViewerOptions reportOption)
    {
       
    }

    [HttpPost]
    public object PostFormReportAction()
    {
        return ReportHelper.ProcessReport(null, this, _cache);
    }


    // Post action to process the report from the server based on json parameters and send the result back to the client.
    [HttpPost]
    public object PostReportAction(Dictionary<string, object> jsonResult)
    {
        return ReportHelper.ProcessReport(jsonResult, this, this._cache);
    }
}
