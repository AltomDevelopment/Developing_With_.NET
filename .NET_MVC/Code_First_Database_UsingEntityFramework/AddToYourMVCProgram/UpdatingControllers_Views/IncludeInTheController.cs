private readonly ILogger<AdminController> _logger;
private readonly DomainContext _context;
        
//In the Constructor of your Controller be sure to pass ILogger(Detailed errors) and your DomainContext as Parameters        
public AdminController(ILogger<AdminController> logger, DomainContext context)
{
     _logger = logger;
    _context = context;
}

//Passing the view a list of Admins from the DomainContext 
public IActionResult Index()
{
    var admins = _context.Admin.ToList();
    return View(admins);
}

//Apply this line of code to the top of your View cshtml file to use the model within your view 
@model List<Code_First_Database_UsingEntityFramework.Models.Admin>

//Example of using the model in the view 
<h2>@Model.ElementAt(0).eMail</h2>