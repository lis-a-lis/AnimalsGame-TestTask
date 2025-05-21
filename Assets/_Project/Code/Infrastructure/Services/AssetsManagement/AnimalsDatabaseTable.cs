using System.Collections.Generic;
using UnityEngine;

namespace _Project.Code.Infrastructure.Services.AssetsManagement
{
    [CreateAssetMenu(menuName = "Create AnimalsDatabaseTable", fileName = "AnimalsDatabaseTable", order = 0)]
    public class AnimalsDatabaseTable : ScriptableObject
    {
        public List<AnimalsDatabaseTableCellIcon> icons;
        public List<AnimalsDatabaseTableCellForm> forms;
        public List<AnimalsDatabaseTableCellColor> colors;
    }
}