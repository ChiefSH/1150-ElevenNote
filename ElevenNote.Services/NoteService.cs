using ElevenNote.Data;
using ElevenNote.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevenNote.Services
{
    public class NoteService
    {
        private readonly Guid _userId;

        public NoteService(Guid userId)
        {
            _userId = userId;
        }

        public IEnumerable<NoteListItemViewModel> GetNotes()
        {
            using (var context = new ElevenNoteDbContext())
            {
                return
                    context
                            .Notes
                            .Where(e => e.OwnerId == _userId)
                            .Select(
                                e =>
                                    new NoteListItemViewModel
                                    {
                                        NoteId = e.NoteId,
                                        Title = e.Title,
                                        CreatedUtc = e.CreatedUtc
                                    })
                            .ToArray();
            }
        }
    }
}
