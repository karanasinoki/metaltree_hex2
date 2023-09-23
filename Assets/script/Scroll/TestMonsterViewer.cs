using UnityEngine;
using System.Linq;

public class TestMonsterViewer : MonoBehaviour
{
    [SerializeField] private MonsterScrollView monsterScrollView;
    void Start()
    {
        var items = Enumerable.Range(0, 10).
            Select(i => new MonsterItemData(i, $"ƒ‚ƒ“ƒXƒ^[{i:D2}")).ToArray();

        monsterScrollView.UpdateData(items);
    }
}

