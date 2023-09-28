using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FancyScrollView;


class MonsterItemData
{
    public int monsterId;
    public string monsterName;

    public MonsterItemData(int id, string monsterName)
    {
        this.monsterId = id;
        this.monsterName = monsterName;
    }
}

class MonsterScrollView : FancyScrollView<MonsterItemData>
{
    [SerializeField] private Scroller _scroller = default;
    [SerializeField] private GameObject _cellPrefab;
    protected override GameObject CellPrefab => _cellPrefab;

    protected override void Initialize()
    {
        _scroller.OnValueChanged(UpdatePosition);
    }

    public void UpdateData(IList<MonsterItemData> items)
    {
        UpdateContents(items);
        _scroller.SetTotalCount(items.Count);
    }
}

