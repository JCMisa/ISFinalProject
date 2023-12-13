using ISFinalProject.Data;
using ISFinalProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ISFinalProject.Controllers
{
	public class BrgyController : Controller
	{
		private readonly ApplicationDbContext _db;
        public BrgyController(ApplicationDbContext db)
        {
			_db = db;
        }

        public async Task<IActionResult> Index()
		{
			List<Barangay?> brgyList = await _db.Barangays.ToListAsync();
			return View(brgyList);
		}

		[HttpGet]
		public IActionResult Create(int? id)
		{
			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,Age,Gender,CivilStatus,HouseNo,Occupation,annualIncome,ContactNo,Gmail")] Barangay brgy)
		{
			if(ModelState.IsValid)
			{
				await _db.Barangays.AddAsync(brgy);
				await _db.SaveChangesAsync();
				return RedirectToAction(nameof(Index));
			}
			return View(brgy);
		}

		public IActionResult Edit(int? id)
		{
			if(id == null || id == 0)
			{
				return NotFound();
			}

			Barangay? brgy = _db.Barangays.FirstOrDefault(u => u.Id == id);

			if(brgy == null)
			{
				return NotFound();
			}

			return View(brgy);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(int? id, [Bind("Id,FirstName,LastName,Age,Gender,CivilStatus,HouseNo,Occupation,annualIncome,ContactNo,Gmail")] Barangay brgy)
		{
			if (id != brgy.Id)
			{
				return NotFound();
			}

			if (ModelState.IsValid)
			{
				_db.Barangays.Update(brgy);
				await _db.SaveChangesAsync();
				return RedirectToAction(nameof(Index));
			}
			return View(brgy);
		}

		public IActionResult Delete(int? id)
		{
			if(id == null || id == 0)
			{
				return NotFound();
			}

			Barangay? brgy = _db.Barangays.FirstOrDefault(u => u.Id == id);

			if(brgy == null)
			{
				return NotFound();
			}

			return View(brgy);
		}

		[HttpPost, ActionName("Delete")]
		public async Task<IActionResult> DeletePost(int? id)
		{
			if (_db.Barangays == null)
			{
				return Problem("Entity set 'ApplicationDbContext.Barangays'  is null.");
			}
			Barangay? brgy = await _db.Barangays.FirstOrDefaultAsync(u => u.Id == id);
			if (brgy != null)
			{
				_db.Barangays.Remove(brgy);
			}

			await _db.SaveChangesAsync();
			return RedirectToAction(nameof(Index));
		}
	}
}
