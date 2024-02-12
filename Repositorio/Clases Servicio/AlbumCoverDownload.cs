using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio.Clases_Servicio
{
    public class AlbumCoverDownload
    {
        
        public async Task Download(string URL)
        {


            using (HttpClient client = new HttpClient())
            {
                byte[] arr = await client.GetByteArrayAsync(URL);

                string albumCoverPath = "C:\\Users\\Usuario\\Desktop\\Proyecto\\AlbumCovers\\";

                int x = Directory.GetFiles(albumCoverPath).Length;

                await File.WriteAllBytesAsync(albumCoverPath + (x + 1).ToString() + ".jpg", arr);


            }

        }
    }
}
