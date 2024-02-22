using DMS.ReposerityServics;
using DMS.Servics;
using DMS.viewModel;
using Microsoft.AspNetCore.Mvc;

namespace DMS.Controllers;

public class DoctoreController : Controller
{
    private readonly IDoctoreRepository _repository;

    public DoctoreController(IDoctoreRepository repository)
    {
        _repository = repository;
    }

    public async Task<ActionResult<DoctorVM>> Index(CancellationToken cancellationToken)
    {
        return View(await _repository.GetAllAsync(cancellationToken));
    }
    [HttpGet]
    public async Task<ActionResult<DoctorVM>> CreateOrEdit(int id, CancellationToken cancellationToken)
    {
        if (id==0)
        {
            return View(new DoctorVM());
            
        }
        else
        {
            return View(await _repository.GetByIdAsyn(id,cancellationToken));
        }
    }
    [HttpPost]
    
    public async Task<ActionResult<DoctorVM>> CreateOrEdit(int id,DoctorVM doctorVM,CancellationToken cancellationToken)
    {
        if (id==0)
        {
          await _repository.InsetAsyn(doctorVM,cancellationToken);
          return RedirectToAction(nameof(Index));
        }
        else
        {
            await _repository.UpdateAsyn(id,doctorVM, cancellationToken);
            return RedirectToAction(nameof(Index));
        }
    }


}
