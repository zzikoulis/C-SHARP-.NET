namespace DLLTextManagementApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DLList<char> fileList = new();
            int totalCharCount = 0;
            char ch;
            string file = @"YOUR_FILEPATH_HERE";
            GenericNode<char> node;

            try
            {
                using var reader = new StreamReader(file);

                while (reader.Peek() >= 0)
                {
                    ch = (char)reader.Read();
                    if ((Convert.ToInt32(ch) == 13) || (Convert.ToInt32(ch) == 10))
                    {
                        reader.Read();
                        continue;
                    }

                    node = fileList.GetNodePosition(ch);
                    if (node != null)
                    {
                        fileList.IncreaseCount(node);
                    }
                    else
                    {
                        fileList.InsertLast(ch);
                    }

                    totalCharCount++;
                }

                Console.WriteLine($"Stats for file: @{file}");
                Console.WriteLine();

                Console.WriteLine("Traverse...");
                fileList.Traverse(totalCharCount);

                Console.WriteLine("Traverse...By Char Asc");
                fileList.SortByValAsc();
                fileList.Traverse(totalCharCount);

                Console.WriteLine("Traverse...By Char Frequency Desc");
                fileList.SortByFrequencyDesc();
                fileList.Traverse(totalCharCount);
            }
            catch (FileNotFoundException e1)
            {
                Console.WriteLine(e1.Message);
            }
            catch (IOException e2)
            {
                Console.WriteLine(e2.Message);
            }
        }
    }
}