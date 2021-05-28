using Library.libraryModel.models;

namespace Library.libraryModel.io
{
    public interface FileManager
    {
        LibraryCl ImportData();
        void ExportData(LibraryCl library);
    }
}
