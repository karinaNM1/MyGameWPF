using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame.Classes
{
    public class QuestCategory
    {
        public string IdQuestCategory { get; set; }
        public string Theme { get; set; }

        public QuestCategory(string idQuestCategory, string theme)
        {
            IdQuestCategory = idQuestCategory;
            Theme = theme;
        }
    }
}
