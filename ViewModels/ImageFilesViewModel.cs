namespace LuminariasWeb.sln.ViewModels
{
    public class ImageFilesViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ContentType { get; set; }
        public string Content { get; set; }
        public string Path { get; set; }
        public string PhysicalPath { get; set; }
        public int Size { get; set; } 
        public DateTime CreateDate { get; set; }
        public byte[] imgByte { get; set; }
    }
}
