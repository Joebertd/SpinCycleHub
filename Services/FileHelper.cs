namespace SpinCycleHub.Helpers
{
    public static class FileHelper
    {
        public static string SaveProof(IFormFile file, string folder)
        {
            if (file == null || file.Length == 0)
                return string.Empty;

            string ext = Path.GetExtension(file.FileName);
            string filename = $"{Guid.NewGuid()}{ext}";
            string path = Path.Combine(folder, filename);

            using (var fs = new FileStream(path, FileMode.Create))
            {
                file.CopyTo(fs);
            }

            return filename;
        }
    }
}
