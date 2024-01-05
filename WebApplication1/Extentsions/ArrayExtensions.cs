using System;

namespace DoranOfficeBackend.Extentsions
{
 
    public static class ArrayExtensions
    {
        public static T[][] MyChunk<T>(this T[] array, int chunkSize)
        {
            int numOfChunks = (int)Math.Ceiling((double)array.Length / chunkSize);
            T[][] chunks = new T[numOfChunks][];

            for (int i = 0; i < numOfChunks; i++)
            {
                int offset = i * chunkSize;
                int size = Math.Min(chunkSize, array.Length - offset);
                T[] chunk = new T[size];
                Array.Copy(array, offset, chunk, 0, size);
                chunks[i] = chunk;
            }

            return chunks;
        }
    }
}
