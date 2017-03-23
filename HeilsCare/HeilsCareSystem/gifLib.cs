using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeilsCareSystem
{
    public class gifLib
    {
        private List<AnimateImage> m_listAnimateImages=new List<AnimateImage>();

        /// <summary>
        /// 添加图片
        /// </summary>
        /// <param name="m_image"></param>
        public void AddAnimateImage(AnimateImage m_image)
        {
            if(m_image.m_imageAnonyName!="")
            {
                m_listAnimateImages.Add(m_image);
            }
            else{
                //必须给图片一个别名（序号)
            }
            
        }
        
        /// <summary>
        /// 删除图片
        /// </summary>
        /// <param name="m_imageName"></param>
        public void RemoveAnimateImage(string m_imageName)
        {
            for(int i=0;i<m_listAnimateImages.Count;i++)
            {
                if (m_imageName==m_listAnimateImages[i].m_imageAnonyName)
                {
                    m_listAnimateImages.RemoveAt(i);
                    break;
                }
            }
        }

        /// <summary>
        /// 获得gif库的gif数量
        /// </summary>
        /// <returns></returns>
        public int GetGifCount() { return m_listAnimateImages.Count; }

        /// <summary>
        /// 获得指定的AnimationGif by index
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public AnimateImage GetImageByindex(int i)
        {
            return m_listAnimateImages[i];
        }

        /// <summary>
        /// 根据图片别名获得图片
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public AnimateImage GetImageByName(string name)
        {
            for(int i=0;i<m_listAnimateImages.Count;i++)
            {
                if (m_listAnimateImages[i].m_imageAnonyName == name)
                    return m_listAnimateImages[i];
            }
            //返回默认第一个，未找到
            return m_listAnimateImages[0];
        }
    }
}
