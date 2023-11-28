using Animal_Status;
using AnimalRepair.BLL.Infrastructure;
using BLL.Interfaces;
using DAL.Interfaces;
using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class NoteService : INoteService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public NoteService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task AddNote(NoteDTO noteDto)
        {
            if (string.IsNullOrEmpty(noteDto.Text))
                throw new ValidationException("Содержание заметки не может быть пустым", "");

            var note = _mapper.Map<NoteDTO, Note>(noteDto);
            await _unitOfWork.Notes.CreateAsync(note);
            _unitOfWork.Save();
        }

        public async Task UpdateNote(NoteDTO noteDto)
        {
            Note updatedNote = _mapper.Map<NoteDTO, Note>(noteDto);
            await _unitOfWork.Notes.UpdateAsync(updatedNote);
            _unitOfWork.Save();
        }

        public async Task RemoveNote(int noteId)
        {
            Note note = await _unitOfWork.Notes.GetAsync(noteId);
            if (note == null)
                throw new ValidationException("Заметка не найдена", "");

            await _unitOfWork.Notes.DeleteAsync(noteId);
            _unitOfWork.Save();
        }

        public async Task<NoteDTO> GetNoteById(int noteId)
        {
            Note note = await _unitOfWork.Notes.GetAsync(noteId);
            if (note == null)
                throw new ValidationException("Заметка не найдена", "");

            NoteDTO noteDto = _mapper.Map<Note, NoteDTO>(note);
            return noteDto;
        }

        public async Task<IEnumerable<NoteDTO>> GetAllNotesAsync()
        {
            IEnumerable<Note> notes = await _unitOfWork.Notes.GetAllAsync();
            return _mapper.Map<IEnumerable<Note>, IEnumerable<NoteDTO>>(notes);
        }

        public void Dispose()
        {
            _unitOfWork.Dispose();
        }
    }
}
