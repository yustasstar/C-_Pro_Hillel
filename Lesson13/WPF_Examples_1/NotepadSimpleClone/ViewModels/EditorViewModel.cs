using NotepadSimpleClone.Models;

namespace NotepadSimpleClone.ViewModels
{
    public class EditorViewModel
    {
        public DocumentModel Document { get; set; }

        public EditorViewModel(DocumentModel document)
        {
            Document = document;
        }
    }
}
