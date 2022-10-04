namespace AspNetCoreAssessment.Manger
{
    public class FileManger
    {
        public static string UploadFile(IFormFile File, string PhysicalPath)
        {
            string FilePath = Directory.GetCurrentDirectory() + PhysicalPath;
            string FileName = Path.GetFileName(File.FileName);
            string finalpath = FilePath + FileName;
            using (var stream = System.IO.File.Create(finalpath))
            {
                File.CopyTo(stream);
            }

            return FileName;
        }
    }
}
