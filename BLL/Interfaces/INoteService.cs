using Animal_Status;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface INoteService : IDisposable
    {
        Task AddNote(NoteDTO noteDto);
        Task UpdateNote(NoteDTO noteDto);
        Task RemoveNote(int noteId);
        Task<NoteDTO> GetNoteById(int noteId);
        Task<IEnumerable<NoteDTO>> GetAllNotesAsync();
    }

}
