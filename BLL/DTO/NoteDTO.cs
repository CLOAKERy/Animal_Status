using System;
using System.Collections.Generic;

namespace Animal_Status;

public partial class NoteDTO
{
    public int NoteId { get; set; }

    public string Title { get; set; } = null!;

    public string Text { get; set; } = null!;

    public int PetId { get; set; }

    public virtual Pet Pet { get; set; } = null!;
}
