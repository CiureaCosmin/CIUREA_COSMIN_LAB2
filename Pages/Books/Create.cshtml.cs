using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Security.Policy;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Nume_Pren_Lab2.Models;
using CIUREA_COSMIN_LAB2.Data;
using CIUREA_COSMIN_LAB2.Models;

namespace CIUREA_COSMIN_LAB2.Pages.Books
{
    public class CreateModel : BookCategoriesPageModel
    {
        private readonly CIUREA_COSMIN_LAB2.Data.CIUREA_COSMIN_LAB2Context _context;

        public CreateModel(CIUREA_COSMIN_LAB2.Data.CIUREA_COSMIN_LAB2Context context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            var authorList = _context.Authors.Select(x => new
            {
                x.ID,
                FullName = x.LastName + " " + x.FirstName
            }
             );
            ViewData["AuthorID"] = new SelectList(authorList, "ID", "FullName");
            ViewData["PublisherID"] = new SelectList(_context.Set<Models.Publisher>(), "ID", "PublisherName");

            var book = new Book();
            book.BookCategories = new List<BookCategory>();
            PopulateAssignedCategoryData(_context, book);

            return Page();
        }

        [BindProperty]
        public Book Book { get; set; }


        public async Task<IActionResult> OnPostAsync(string[] selectedCategories)
        {
            var newBook = Book;
            if (selectedCategories != null)
            {
                newBook.BookCategories = new List<BookCategory>();
                foreach (var cat in selectedCategories)
                {
                    var catToAdd = new BookCategory
                    {
                        CategoryID = int.Parse(cat)
                    };
                    newBook.BookCategories.Add(catToAdd);
                }
            }
             /* if (await TryUpdateModelAsync<Book>(
             newBook,
             "Book",
             i => i.Title, i => i.AuthorID,
             i => i.Price, i => i.PublishingDate, i => i.PublisherID))
             {
                 _context.Book.Add(newBook);
                 await _context.SaveChangesAsync();
                 return RedirectToPage("./Index");
             } */
            _context.Book.Add(newBook);
            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");


            PopulateAssignedCategoryData(_context, newBook);
            return Page();
        }
    }
    
}
