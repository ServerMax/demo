using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml;

public class AutoConfig
{
    //enums.xls

    /**/
    public enum Dir
    {
        up = 0, /*上*/
        down = 1, /*下*/
        left = 2, /*左*/
        right = 3, /*右*/
    };

    /**/
    public enum RewardType
    {
        coin = 0, /*金币*/
        mecha = 1, /*机甲*/
        primaryWeapon = 2, /*主武器*/
        rightWeapon = 3, /*右手武器*/
        equipment = 4, /*附加装备*/
        armor = 5, /*装甲*/
    };

    /**/
    public enum TaskType
    {
        killMech = 0, /*击杀机甲数量*/
        signed = 1, /*连续签到天数*/
        watchAD = 2, /*看广告次数*/
        playGames = 3, /*玩游戏局数*/
        flagMode = 4, /*夺旗模式胜利次数*/
        pointMode = 5, /*控制点模式胜利次数*/
        bombMode = 6, /*运输炸弹模式胜利次数*/
    };

    //structs.xls

    /**/
    public class oChestItem
    {
        /*权重*/
        public readonly int _weight;
        /*奖励类型(0:金币，1:机甲，2:主武器，3:右手武器，4:附加装备，5:装甲)*/
        public readonly int _type;
        /*机甲部件id，-1是纯随机，-2是随机未拥有。如果是金币，填数量*/
        public readonly int _param;
        public oChestItem(int weight, int type, int param) {
            _weight = weight;
            _type = type;
            _param = param;
        }
    };
    /**/
    public class oCommonReward
    {
        /*奖励类型(0:金币，1:机甲，2:主武器，3:右手武器，4:附加装备，5:装甲)*/
        public readonly int _type;
        /*奖励ID*/
        public readonly int _id;
        /*奖励数量*/
        public readonly int _num;
        public oCommonReward(int type, int id, int num) {
            _type = type;
            _id = id;
            _num = num;
        }
    };
    /*oItemInfo*/
    public class oItemInfo
    {
        /*类型*/
        public readonly int _type;
        /*id*/
        public readonly int _id;
        /*数量*/
        public readonly int _num;
        public oItemInfo(int type, int id, int num) {
            _type = type;
            _id = id;
            _num = num;
        }
    };
    /**/
    public class oMech
    {
        /*机甲id*/
        public readonly int _id;
        /*ai类型*/
        public readonly int _ai_type;
        /*机甲数量*/
        public readonly int _number;
        public oMech(int id, int ai_type, int number) {
            _id = id;
            _ai_type = ai_type;
            _number = number;
        }
    };
    /**/
    public class oTaskLimitReward
    {
        /*奖励类型(0:金币，1:机甲，2:主武器，3:右手武器，4:附加装备，5:装甲)*/
        public readonly int _type;
        /*奖励ID*/
        public readonly int _id;
        /*奖励数量*/
        public readonly int _num;
        /*所需经验*/
        public readonly int _exp;
        public oTaskLimitReward(int type, int id, int num, int exp) {
            _type = type;
            _id = id;
            _num = num;
            _exp = exp;
        }
    };
    /**/
    public class oVec3
    {
        /*x坐标*/
        public readonly float _x;
        /*y坐标*/
        public readonly float _y;
        /*z坐标*/
        public readonly float _z;
        public oVec3(float x, float y, float z) {
            _x = x;
            _y = y;
            _z = z;
        }
    };
    //ArmorData.xls
    public class o_config_ArmorData
    {
        public int id; /*ID*/
        public string name; /*名称*/
        public int sort; /*排序*/
        public string prefab; /*预制*/
        public string icon; /*图标*/
        public int price; /*价格*/
        public int life; /*生命*/
        public int skill; /*技能ID*/
        public string effect; /*特殊效果*/
    }
    public IDictionary<int, o_config_ArmorData> o_config_ArmorData_map;
    void init_config_ArmorData(string path)
    {
        o_config_ArmorData_map = new Dictionary<int, o_config_ArmorData>();

        XmlDocument doc =  _xmlloader(path, "ArmorData");
        XmlNode root = doc.SelectSingleNode("root");

        XmlNode node = root.FirstChild;
        while(null != node)
        {
            o_config_ArmorData o = new o_config_ArmorData();
            o.id = (int)float.Parse(node.Attributes["id"].Value);
            o.name = node.Attributes["name"].Value;
            o.sort = (int)float.Parse(node.Attributes["sort"].Value);
            o.prefab = node.Attributes["prefab"].Value;
            o.icon = node.Attributes["icon"].Value;
            o.price = (int)float.Parse(node.Attributes["price"].Value);
            o.life = (int)float.Parse(node.Attributes["life"].Value);
            o.skill = (int)float.Parse(node.Attributes["skill"].Value);
            o.effect = node.Attributes["effect"].Value;

            o_config_ArmorData_map.Add(o.id, o);
            node = node.NextSibling;
        }
    }
    //BuffData.xls
    public class o_config_BuffData
    {
        public int id; /*ID*/
        public string name; /*名称*/
        public int canOverlying; /*是否可叠加*/
        public string effName; /*特效名称*/
        public int jointId; /*作用节点
0：主武器
1：右手武器
2：近战武器
3：特殊武器
4：引擎
5：辅助装置
6：炮塔
7：装甲
100：主体中心
101：脚底*/
    }
    public IDictionary<int, o_config_BuffData> o_config_BuffData_map;
    void init_config_BuffData(string path)
    {
        o_config_BuffData_map = new Dictionary<int, o_config_BuffData>();

        XmlDocument doc =  _xmlloader(path, "BuffData");
        XmlNode root = doc.SelectSingleNode("root");

        XmlNode node = root.FirstChild;
        while(null != node)
        {
            o_config_BuffData o = new o_config_BuffData();
            o.id = (int)float.Parse(node.Attributes["id"].Value);
            o.name = node.Attributes["name"].Value;
            o.canOverlying = (int)float.Parse(node.Attributes["canOverlying"].Value);
            o.effName = node.Attributes["effName"].Value;
            o.jointId = (int)float.Parse(node.Attributes["jointId"].Value);

            o_config_BuffData_map.Add(o.id, o);
            node = node.NextSibling;
        }
    }
    //BulletData.xls
    public class o_config_BulletData
    {
        public int id; /*ID*/
        public string name; /*名字*/
        public int type; /*类型
0:子弹
1：受重力影响的炮弹*/
        public float reboundParam; /*反弹系数*/
        public int isExplosion; /*是否爆炸*/
        public int isExplosion_hit; /*碰撞后是否爆炸（是爆炸不是命中）*/
        public int explosionRange; /*爆炸伤害半径*/
        public string prefab; /*预制*/
        public string emissiveColor; /*自发光颜色*/
        public int emissiveScale; /*自发光强度*/
        public string eff_hit; /*打击特效*/
        public string eff_explosion; /*爆炸特效*/
        public float explosionScale; /*爆炸特效缩放*/
        public string eff_trail; /*拖尾特效*/
    }
    public IDictionary<int, o_config_BulletData> o_config_BulletData_map;
    void init_config_BulletData(string path)
    {
        o_config_BulletData_map = new Dictionary<int, o_config_BulletData>();

        XmlDocument doc =  _xmlloader(path, "BulletData");
        XmlNode root = doc.SelectSingleNode("root");

        XmlNode node = root.FirstChild;
        while(null != node)
        {
            o_config_BulletData o = new o_config_BulletData();
            o.id = (int)float.Parse(node.Attributes["id"].Value);
            o.name = node.Attributes["name"].Value;
            o.type = (int)float.Parse(node.Attributes["type"].Value);
            o.reboundParam = float.Parse(node.Attributes["reboundParam"].Value);
            o.isExplosion = (int)float.Parse(node.Attributes["isExplosion"].Value);
            o.isExplosion_hit = (int)float.Parse(node.Attributes["isExplosion_hit"].Value);
            o.explosionRange = (int)float.Parse(node.Attributes["explosionRange"].Value);
            o.prefab = node.Attributes["prefab"].Value;
            o.emissiveColor = node.Attributes["emissiveColor"].Value;
            o.emissiveScale = (int)float.Parse(node.Attributes["emissiveScale"].Value);
            o.eff_hit = node.Attributes["eff_hit"].Value;
            o.eff_explosion = node.Attributes["eff_explosion"].Value;
            o.explosionScale = float.Parse(node.Attributes["explosionScale"].Value);
            o.eff_trail = node.Attributes["eff_trail"].Value;

            o_config_BulletData_map.Add(o.id, o);
            node = node.NextSibling;
        }
    }
    //CoinData.xls
    public class o_config_CoinData
    {
        public int id; /*id*/
        public string name; /*名称*/
        public string icon; /*图标*/
    }
    public IDictionary<int, o_config_CoinData> o_config_CoinData_map;
    void init_config_CoinData(string path)
    {
        o_config_CoinData_map = new Dictionary<int, o_config_CoinData>();

        XmlDocument doc =  _xmlloader(path, "CoinData");
        XmlNode root = doc.SelectSingleNode("root");

        XmlNode node = root.FirstChild;
        while(null != node)
        {
            o_config_CoinData o = new o_config_CoinData();
            o.id = (int)float.Parse(node.Attributes["id"].Value);
            o.name = node.Attributes["name"].Value;
            o.icon = node.Attributes["icon"].Value;

            o_config_CoinData_map.Add(o.id, o);
            node = node.NextSibling;
        }
    }
    //EngineData.xls
    public class o_config_EngineData
    {
        public int id; /*ID*/
        public string name; /*名称*/
        public int sort; /*排序*/
        public string prefab; /*预制*/
        public string icon; /*图标*/
        public int price; /*价格*/
        public int skill; /*技能ID*/
        public string effect; /*特殊效果*/
    }
    public IDictionary<int, o_config_EngineData> o_config_EngineData_map;
    void init_config_EngineData(string path)
    {
        o_config_EngineData_map = new Dictionary<int, o_config_EngineData>();

        XmlDocument doc =  _xmlloader(path, "EngineData");
        XmlNode root = doc.SelectSingleNode("root");

        XmlNode node = root.FirstChild;
        while(null != node)
        {
            o_config_EngineData o = new o_config_EngineData();
            o.id = (int)float.Parse(node.Attributes["id"].Value);
            o.name = node.Attributes["name"].Value;
            o.sort = (int)float.Parse(node.Attributes["sort"].Value);
            o.prefab = node.Attributes["prefab"].Value;
            o.icon = node.Attributes["icon"].Value;
            o.price = (int)float.Parse(node.Attributes["price"].Value);
            o.skill = (int)float.Parse(node.Attributes["skill"].Value);
            o.effect = node.Attributes["effect"].Value;

            o_config_EngineData_map.Add(o.id, o);
            node = node.NextSibling;
        }
    }
    //EquipmentData.xls
    public class o_config_EquipmentData
    {
        public int id; /*ID*/
        public string name; /*名称*/
        public int sort; /*排序*/
        public string prefab; /*预制*/
        public string icon; /*图标*/
        public int price; /*价格*/
        public int skill; /*技能ID*/
        public string effect; /*特殊效果*/
    }
    public IDictionary<int, o_config_EquipmentData> o_config_EquipmentData_map;
    void init_config_EquipmentData(string path)
    {
        o_config_EquipmentData_map = new Dictionary<int, o_config_EquipmentData>();

        XmlDocument doc =  _xmlloader(path, "EquipmentData");
        XmlNode root = doc.SelectSingleNode("root");

        XmlNode node = root.FirstChild;
        while(null != node)
        {
            o_config_EquipmentData o = new o_config_EquipmentData();
            o.id = (int)float.Parse(node.Attributes["id"].Value);
            o.name = node.Attributes["name"].Value;
            o.sort = (int)float.Parse(node.Attributes["sort"].Value);
            o.prefab = node.Attributes["prefab"].Value;
            o.icon = node.Attributes["icon"].Value;
            o.price = (int)float.Parse(node.Attributes["price"].Value);
            o.skill = (int)float.Parse(node.Attributes["skill"].Value);
            o.effect = node.Attributes["effect"].Value;

            o_config_EquipmentData_map.Add(o.id, o);
            node = node.NextSibling;
        }
    }
    //FreeCoinData.xls
    public class o_config_FreeCoinData
    {
        public int id; /*id*/
        public int number; /*数量*/
    }
    public IDictionary<int, o_config_FreeCoinData> o_config_FreeCoinData_map;
    void init_config_FreeCoinData(string path)
    {
        o_config_FreeCoinData_map = new Dictionary<int, o_config_FreeCoinData>();

        XmlDocument doc =  _xmlloader(path, "FreeCoinData");
        XmlNode root = doc.SelectSingleNode("root");

        XmlNode node = root.FirstChild;
        while(null != node)
        {
            o_config_FreeCoinData o = new o_config_FreeCoinData();
            o.id = (int)float.Parse(node.Attributes["id"].Value);
            o.number = (int)float.Parse(node.Attributes["number"].Value);

            o_config_FreeCoinData_map.Add(o.id, o);
            node = node.NextSibling;
        }
    }
    //LevelData.xls
    public class o_config_LevelData
    {
        public int id; /*id*/
        public string name; /*名称*/
        public string prefabName; /*预制名*/
        public string sdfName; /*sdf资源名*/
        public float baseHeight; /*基准地面高度*/
        public int gameMode; /*游戏模式
0：夺旗
1：占领
2：运输*/
        public string weapons; /*武器*/
        public IList<oMech> smallmech;/*敌方小兵类型*/
        public int baseAward; /*关卡基础奖励*/
        public int unlockMech; /*解锁小兵ID*/
        public int isTeaching; /*是否是教学关
0：没有教学
1：有教学*/
        public float enemyRebornInv; /*敌人复活间隔*/
    }
    public IDictionary<int, o_config_LevelData> o_config_LevelData_map;
    void init_config_LevelData(string path)
    {
        o_config_LevelData_map = new Dictionary<int, o_config_LevelData>();

        XmlDocument doc =  _xmlloader(path, "LevelData");
        XmlNode root = doc.SelectSingleNode("root");

        XmlNode node = root.FirstChild;
        while(null != node)
        {
            o_config_LevelData o = new o_config_LevelData();
            o.id = (int)float.Parse(node.Attributes["id"].Value);
            o.name = node.Attributes["name"].Value;
            o.prefabName = node.Attributes["prefabName"].Value;
            o.sdfName = node.Attributes["sdfName"].Value;
            o.baseHeight = float.Parse(node.Attributes["baseHeight"].Value);
            o.gameMode = (int)float.Parse(node.Attributes["gameMode"].Value);
            o.weapons = node.Attributes["weapons"].Value;

            o.smallmech = new List<oMech>();
            string[] smallmech_values = node.Attributes["smallmech"].Value.Split(';');
            for (int i = 0; i < smallmech_values.Length; i++)
            {
                string[] oMech_values = smallmech_values[i].Split(',');
                oMech oo = new oMech((int)float.Parse(oMech_values[0]), (int)float.Parse(oMech_values[1]), (int)float.Parse(oMech_values[2]));

                o.smallmech.Add(oo);
            }
            o.baseAward = (int)float.Parse(node.Attributes["baseAward"].Value);
            o.unlockMech = (int)float.Parse(node.Attributes["unlockMech"].Value);
            o.isTeaching = (int)float.Parse(node.Attributes["isTeaching"].Value);
            o.enemyRebornInv = float.Parse(node.Attributes["enemyRebornInv"].Value);

            o_config_LevelData_map.Add(o.id, o);
            node = node.NextSibling;
        }
    }
    //LotteryData.xls
    public class o_config_LotteryData
    {
        public int id; /*id*/
        public oCommonReward reward_list; /*奖励*/
        public int weight; /*权重*/
    }
    public IDictionary<int, o_config_LotteryData> o_config_LotteryData_map;
    void init_config_LotteryData(string path)
    {
        o_config_LotteryData_map = new Dictionary<int, o_config_LotteryData>();

        XmlDocument doc =  _xmlloader(path, "LotteryData");
        XmlNode root = doc.SelectSingleNode("root");

        XmlNode node = root.FirstChild;
        while(null != node)
        {
            o_config_LotteryData o = new o_config_LotteryData();
            o.id = (int)float.Parse(node.Attributes["id"].Value);
            string[] reward_list_values = node.Attributes["reward_list"].Value.Split(',');
            o.reward_list = new oCommonReward(
                (int)float.Parse(reward_list_values[0]),
                (int)float.Parse(reward_list_values[1]),
                (int)float.Parse(reward_list_values[2])
            );
            o.weight = (int)float.Parse(node.Attributes["weight"].Value);

            o_config_LotteryData_map.Add(o.id, o);
            node = node.NextSibling;
        }
    }
    //MaskData.xls
    public class o_config_MaskData
    {
        public int id; /*ID*/
        public string name; /*名称*/
        public int sort; /*排序*/
        public string prefab; /*预制*/
        public string icon; /*图标*/
        public int price; /*价格*/
        public int life; /*生命*/
        public int speed; /*速度*/
        public string effect; /*特殊效果*/
    }
    public IDictionary<int, o_config_MaskData> o_config_MaskData_map;
    void init_config_MaskData(string path)
    {
        o_config_MaskData_map = new Dictionary<int, o_config_MaskData>();

        XmlDocument doc =  _xmlloader(path, "MaskData");
        XmlNode root = doc.SelectSingleNode("root");

        XmlNode node = root.FirstChild;
        while(null != node)
        {
            o_config_MaskData o = new o_config_MaskData();
            o.id = (int)float.Parse(node.Attributes["id"].Value);
            o.name = node.Attributes["name"].Value;
            o.sort = (int)float.Parse(node.Attributes["sort"].Value);
            o.prefab = node.Attributes["prefab"].Value;
            o.icon = node.Attributes["icon"].Value;
            o.price = (int)float.Parse(node.Attributes["price"].Value);
            o.life = (int)float.Parse(node.Attributes["life"].Value);
            o.speed = (int)float.Parse(node.Attributes["speed"].Value);
            o.effect = node.Attributes["effect"].Value;

            o_config_MaskData_map.Add(o.id, o);
            node = node.NextSibling;
        }
    }
    //MechaData.xls
    public class o_config_MechaData
    {
        public int id; /*机甲ID*/
        public string name; /*机甲名称*/
        public int sort; /*排序*/
        public string prefab; /*预制*/
        public int type; /*类型
0：玩家
1：杂兵
2：守卫*/
        public int bodyType; /*机体类型
0：双足式
1：轮式
2：爬行式
3：蝎式
4：高达式
5:坦克式*/
        public string icon; /*图标*/
        public string describe; /*描述*/
        public int price; /*价格（0表示组装机）*/
        public float bodyRange; /*体积范围*/
        public int hpBase; /*基础血量*/
        public int spdBase; /*基础速度*/
        public int dmgPmBase; /*基础伤害千分比*/
        public int expBase; /*基础经验掉落*/
        public int hpInc; /*血量提升*/
        public int spdInc; /*速度提升*/
        public int dmgPmInc; /*伤害千分比提升*/
        public int expInc; /*经验掉落提升*/
        public int init_weapon; /*初始武器*/
        public int init_color; /*初始颜色*/
        public string texName; /*默认贴图名*/
        public string blueTexName; /*蓝色贴图名
(仅杂兵有效)*/
        public string redTexName; /*红色贴图名
(仅杂兵有效)*/
        public string primary_weapon; /*主武器种类*/
        public string second_weapon; /*副武器种类*/
        public string right_weapon; /*右手武器种类*/
        public string melee_weapon; /*近战武器种类*/
        public string special_weapon; /*特殊武器种类*/
        public string tuffet; /*炮塔种类*/
        public string mask; /*面具种类*/
        public string armor; /*装甲种类*/
        public string equipment; /*附加装备*/
        public string engine; /*引擎*/
        public int summonedAiType; /*作为召唤单位的AI类型
0：战士
1：护卫
2：侦察兵
3：岗哨*/
    }
    public IDictionary<int, o_config_MechaData> o_config_MechaData_map;
    void init_config_MechaData(string path)
    {
        o_config_MechaData_map = new Dictionary<int, o_config_MechaData>();

        XmlDocument doc =  _xmlloader(path, "MechaData");
        XmlNode root = doc.SelectSingleNode("root");

        XmlNode node = root.FirstChild;
        while(null != node)
        {
            o_config_MechaData o = new o_config_MechaData();
            o.id = (int)float.Parse(node.Attributes["id"].Value);
            o.name = node.Attributes["name"].Value;
            o.sort = (int)float.Parse(node.Attributes["sort"].Value);
            o.prefab = node.Attributes["prefab"].Value;
            o.type = (int)float.Parse(node.Attributes["type"].Value);
            o.bodyType = (int)float.Parse(node.Attributes["bodyType"].Value);
            o.icon = node.Attributes["icon"].Value;
            o.describe = node.Attributes["describe"].Value;
            o.price = (int)float.Parse(node.Attributes["price"].Value);
            o.bodyRange = float.Parse(node.Attributes["bodyRange"].Value);
            o.hpBase = (int)float.Parse(node.Attributes["hpBase"].Value);
            o.spdBase = (int)float.Parse(node.Attributes["spdBase"].Value);
            o.dmgPmBase = (int)float.Parse(node.Attributes["dmgPmBase"].Value);
            o.expBase = (int)float.Parse(node.Attributes["expBase"].Value);
            o.hpInc = (int)float.Parse(node.Attributes["hpInc"].Value);
            o.spdInc = (int)float.Parse(node.Attributes["spdInc"].Value);
            o.dmgPmInc = (int)float.Parse(node.Attributes["dmgPmInc"].Value);
            o.expInc = (int)float.Parse(node.Attributes["expInc"].Value);
            o.init_weapon = (int)float.Parse(node.Attributes["init_weapon"].Value);
            o.init_color = (int)float.Parse(node.Attributes["init_color"].Value);
            o.texName = node.Attributes["texName"].Value;
            o.blueTexName = node.Attributes["blueTexName"].Value;
            o.redTexName = node.Attributes["redTexName"].Value;
            o.primary_weapon = node.Attributes["primary_weapon"].Value;
            o.second_weapon = node.Attributes["second_weapon"].Value;
            o.right_weapon = node.Attributes["right_weapon"].Value;
            o.melee_weapon = node.Attributes["melee_weapon"].Value;
            o.special_weapon = node.Attributes["special_weapon"].Value;
            o.tuffet = node.Attributes["tuffet"].Value;
            o.mask = node.Attributes["mask"].Value;
            o.armor = node.Attributes["armor"].Value;
            o.equipment = node.Attributes["equipment"].Value;
            o.engine = node.Attributes["engine"].Value;
            o.summonedAiType = (int)float.Parse(node.Attributes["summonedAiType"].Value);

            o_config_MechaData_map.Add(o.id, o);
            node = node.NextSibling;
        }
    }
    //MechColorData.xls
    public class o_config_MechColorData
    {
        public int id; /*id*/
        public string name; /*名称*/
        public float widthRatio; /*宽度所占贴图比例*/
        public float heightRatio; /*高度所占贴图比例*/
        public float offsetX; /*截取起始点偏移X*/
        public float offsetY; /*截取起始点偏移Y*/
    }
    public IDictionary<int, o_config_MechColorData> o_config_MechColorData_map;
    void init_config_MechColorData(string path)
    {
        o_config_MechColorData_map = new Dictionary<int, o_config_MechColorData>();

        XmlDocument doc =  _xmlloader(path, "MechColorData");
        XmlNode root = doc.SelectSingleNode("root");

        XmlNode node = root.FirstChild;
        while(null != node)
        {
            o_config_MechColorData o = new o_config_MechColorData();
            o.id = (int)float.Parse(node.Attributes["id"].Value);
            o.name = node.Attributes["name"].Value;
            o.widthRatio = float.Parse(node.Attributes["widthRatio"].Value);
            o.heightRatio = float.Parse(node.Attributes["heightRatio"].Value);
            o.offsetX = float.Parse(node.Attributes["offsetX"].Value);
            o.offsetY = float.Parse(node.Attributes["offsetY"].Value);

            o_config_MechColorData_map.Add(o.id, o);
            node = node.NextSibling;
        }
    }
    //MeleeWeaponData.xls
    public class o_config_MeleeWeaponData
    {
        public int id; /*ID*/
        public string name; /*名称*/
        public int sort; /*排序*/
        public string prefab; /*预制*/
        public string icon; /*图标*/
        public int price; /*价格*/
        public int dps; /*伤害*/
        public int skill; /*技能ID*/
        public string sound_effect; /*音效*/
        public string special_effect; /*特殊效果*/
    }
    public IDictionary<int, o_config_MeleeWeaponData> o_config_MeleeWeaponData_map;
    void init_config_MeleeWeaponData(string path)
    {
        o_config_MeleeWeaponData_map = new Dictionary<int, o_config_MeleeWeaponData>();

        XmlDocument doc =  _xmlloader(path, "MeleeWeaponData");
        XmlNode root = doc.SelectSingleNode("root");

        XmlNode node = root.FirstChild;
        while(null != node)
        {
            o_config_MeleeWeaponData o = new o_config_MeleeWeaponData();
            o.id = (int)float.Parse(node.Attributes["id"].Value);
            o.name = node.Attributes["name"].Value;
            o.sort = (int)float.Parse(node.Attributes["sort"].Value);
            o.prefab = node.Attributes["prefab"].Value;
            o.icon = node.Attributes["icon"].Value;
            o.price = (int)float.Parse(node.Attributes["price"].Value);
            o.dps = (int)float.Parse(node.Attributes["dps"].Value);
            o.skill = (int)float.Parse(node.Attributes["skill"].Value);
            o.sound_effect = node.Attributes["sound_effect"].Value;
            o.special_effect = node.Attributes["special_effect"].Value;

            o_config_MeleeWeaponData_map.Add(o.id, o);
            node = node.NextSibling;
        }
    }
    //OpenChestData.xls
    public class o_config_OpenChestData
    {
        public int id; /*ID*/
        public string name; /*名称*/
        public oChestItem obj1; /*结果1*/
        public oChestItem obj2; /*结果2*/
        public oChestItem obj3; /*结果3*/
        public oChestItem obj4; /*结果4*/
        public oChestItem obj5; /*结果5*/
        public oChestItem obj6; /*结果6*/
        public oChestItem obj7; /*结果7*/
        public oChestItem obj8; /*结果8*/
        public oChestItem obj9; /*结果9*/
        public oChestItem obj10; /*结果10*/
    }
    public IDictionary<int, o_config_OpenChestData> o_config_OpenChestData_map;
    void init_config_OpenChestData(string path)
    {
        o_config_OpenChestData_map = new Dictionary<int, o_config_OpenChestData>();

        XmlDocument doc =  _xmlloader(path, "OpenChestData");
        XmlNode root = doc.SelectSingleNode("root");

        XmlNode node = root.FirstChild;
        while(null != node)
        {
            o_config_OpenChestData o = new o_config_OpenChestData();
            o.id = (int)float.Parse(node.Attributes["id"].Value);
            o.name = node.Attributes["name"].Value;
            string[] obj1_values = node.Attributes["obj1"].Value.Split(',');
            o.obj1 = new oChestItem(
                (int)float.Parse(obj1_values[0]),
                (int)float.Parse(obj1_values[1]),
                (int)float.Parse(obj1_values[2])
            );
            string[] obj2_values = node.Attributes["obj2"].Value.Split(',');
            o.obj2 = new oChestItem(
                (int)float.Parse(obj2_values[0]),
                (int)float.Parse(obj2_values[1]),
                (int)float.Parse(obj2_values[2])
            );
            string[] obj3_values = node.Attributes["obj3"].Value.Split(',');
            o.obj3 = new oChestItem(
                (int)float.Parse(obj3_values[0]),
                (int)float.Parse(obj3_values[1]),
                (int)float.Parse(obj3_values[2])
            );
            string[] obj4_values = node.Attributes["obj4"].Value.Split(',');
            o.obj4 = new oChestItem(
                (int)float.Parse(obj4_values[0]),
                (int)float.Parse(obj4_values[1]),
                (int)float.Parse(obj4_values[2])
            );
            string[] obj5_values = node.Attributes["obj5"].Value.Split(',');
            o.obj5 = new oChestItem(
                (int)float.Parse(obj5_values[0]),
                (int)float.Parse(obj5_values[1]),
                (int)float.Parse(obj5_values[2])
            );
            string[] obj6_values = node.Attributes["obj6"].Value.Split(',');
            o.obj6 = new oChestItem(
                (int)float.Parse(obj6_values[0]),
                (int)float.Parse(obj6_values[1]),
                (int)float.Parse(obj6_values[2])
            );
            string[] obj7_values = node.Attributes["obj7"].Value.Split(',');
            o.obj7 = new oChestItem(
                (int)float.Parse(obj7_values[0]),
                (int)float.Parse(obj7_values[1]),
                (int)float.Parse(obj7_values[2])
            );
            string[] obj8_values = node.Attributes["obj8"].Value.Split(',');
            o.obj8 = new oChestItem(
                (int)float.Parse(obj8_values[0]),
                (int)float.Parse(obj8_values[1]),
                (int)float.Parse(obj8_values[2])
            );
            string[] obj9_values = node.Attributes["obj9"].Value.Split(',');
            o.obj9 = new oChestItem(
                (int)float.Parse(obj9_values[0]),
                (int)float.Parse(obj9_values[1]),
                (int)float.Parse(obj9_values[2])
            );
            string[] obj10_values = node.Attributes["obj10"].Value.Split(',');
            o.obj10 = new oChestItem(
                (int)float.Parse(obj10_values[0]),
                (int)float.Parse(obj10_values[1]),
                (int)float.Parse(obj10_values[2])
            );

            o_config_OpenChestData_map.Add(o.id, o);
            node = node.NextSibling;
        }
    }
    //PrimaryWeaponData.xls
    public class o_config_PrimaryWeaponData
    {
        public int id; /*编号*/
        public string name; /*名称*/
        public int sort; /*排序*/
        public string prefab; /*预制*/
        public string icon; /*图标*/
        public int price; /*价格*/
        public int snipeMode; /*是否有狙击模式
0：没有
1：有*/
        public int attackType; /*攻击类型
0：发射飞行道具
1：攻击帧伤害
2：激光伤害
3：火焰伤害*/
        public int attackPerMin; /*每分钟攻击次数*/
        public int dps; /*每秒伤害*/
        public int bullet; /*炮弹ID*/
        public int shoot_number; /*每次发射的子弹数*/
        public int distance; /*射程*/
        public int bullet_speed; /*弹道速度*/
        public string scatter; /*散射角度*/
        public float vertAngleFix; /*发射角度垂直方向修正*/
        public string effectName; /*外挂特效名*/
        public string aniName; /*播放动画名*/
        public int dmgAreaType; /*伤害区域类型
0：以自身为圆心的圆形区域（旋风斩类）
1：前方矩形（激光类）
2：前方锥形（火焰喷射器类）
区域半径由射程决定*/
        public float rayWidth; /*激光类武器宽度*/
        public float heat_quantity; /*发射热量（0表示没有过热限制）*/
        public string special_effect; /*特殊效果*/
        public string sound_effect; /*音效*/
    }
    public IDictionary<int, o_config_PrimaryWeaponData> o_config_PrimaryWeaponData_map;
    void init_config_PrimaryWeaponData(string path)
    {
        o_config_PrimaryWeaponData_map = new Dictionary<int, o_config_PrimaryWeaponData>();

        XmlDocument doc =  _xmlloader(path, "PrimaryWeaponData");
        XmlNode root = doc.SelectSingleNode("root");

        XmlNode node = root.FirstChild;
        while(null != node)
        {
            o_config_PrimaryWeaponData o = new o_config_PrimaryWeaponData();
            o.id = (int)float.Parse(node.Attributes["id"].Value);
            o.name = node.Attributes["name"].Value;
            o.sort = (int)float.Parse(node.Attributes["sort"].Value);
            o.prefab = node.Attributes["prefab"].Value;
            o.icon = node.Attributes["icon"].Value;
            o.price = (int)float.Parse(node.Attributes["price"].Value);
            o.snipeMode = (int)float.Parse(node.Attributes["snipeMode"].Value);
            o.attackType = (int)float.Parse(node.Attributes["attackType"].Value);
            o.attackPerMin = (int)float.Parse(node.Attributes["attackPerMin"].Value);
            o.dps = (int)float.Parse(node.Attributes["dps"].Value);
            o.bullet = (int)float.Parse(node.Attributes["bullet"].Value);
            o.shoot_number = (int)float.Parse(node.Attributes["shoot_number"].Value);
            o.distance = (int)float.Parse(node.Attributes["distance"].Value);
            o.bullet_speed = (int)float.Parse(node.Attributes["bullet_speed"].Value);
            o.scatter = node.Attributes["scatter"].Value;
            o.vertAngleFix = float.Parse(node.Attributes["vertAngleFix"].Value);
            o.effectName = node.Attributes["effectName"].Value;
            o.aniName = node.Attributes["aniName"].Value;
            o.dmgAreaType = (int)float.Parse(node.Attributes["dmgAreaType"].Value);
            o.rayWidth = float.Parse(node.Attributes["rayWidth"].Value);
            o.heat_quantity = float.Parse(node.Attributes["heat_quantity"].Value);
            o.special_effect = node.Attributes["special_effect"].Value;
            o.sound_effect = node.Attributes["sound_effect"].Value;

            o_config_PrimaryWeaponData_map.Add(o.id, o);
            node = node.NextSibling;
        }
    }
    //RandomData.xls
    public class o_config_RandomData
    {
        public int id; /*id*/
        public oCommonReward reward_list; /*奖励*/
        public int weight; /*权重*/
    }
    public IDictionary<int, o_config_RandomData> o_config_RandomData_map;
    void init_config_RandomData(string path)
    {
        o_config_RandomData_map = new Dictionary<int, o_config_RandomData>();

        XmlDocument doc =  _xmlloader(path, "RandomData");
        XmlNode root = doc.SelectSingleNode("root");

        XmlNode node = root.FirstChild;
        while(null != node)
        {
            o_config_RandomData o = new o_config_RandomData();
            o.id = (int)float.Parse(node.Attributes["id"].Value);
            string[] reward_list_values = node.Attributes["reward_list"].Value.Split(',');
            o.reward_list = new oCommonReward(
                (int)float.Parse(reward_list_values[0]),
                (int)float.Parse(reward_list_values[1]),
                (int)float.Parse(reward_list_values[2])
            );
            o.weight = (int)float.Parse(node.Attributes["weight"].Value);

            o_config_RandomData_map.Add(o.id, o);
            node = node.NextSibling;
        }
    }
    //RankData.xls
    public class o_config_RankData
    {
        public int id; /*ID*/
        public string name; /*军衔名称*/
        public int exp; /*经验*/
        public int getPoint; /*获得技能点数*/
    }
    public IDictionary<int, o_config_RankData> o_config_RankData_map;
    void init_config_RankData(string path)
    {
        o_config_RankData_map = new Dictionary<int, o_config_RankData>();

        XmlDocument doc =  _xmlloader(path, "RankData");
        XmlNode root = doc.SelectSingleNode("root");

        XmlNode node = root.FirstChild;
        while(null != node)
        {
            o_config_RankData o = new o_config_RankData();
            o.id = (int)float.Parse(node.Attributes["id"].Value);
            o.name = node.Attributes["name"].Value;
            o.exp = (int)float.Parse(node.Attributes["exp"].Value);
            o.getPoint = (int)float.Parse(node.Attributes["getPoint"].Value);

            o_config_RankData_map.Add(o.id, o);
            node = node.NextSibling;
        }
    }
    //RightWeaponData.xls
    public class o_config_RightWeaponData
    {
        public int id; /*编号*/
        public string name; /*名称*/
        public int sort; /*排序*/
        public string prefab; /*预制*/
        public string icon; /*图标*/
        public int price; /*价格*/
        public int dps; /*伤害*/
        public int bullet; /*炮弹ID*/
        public int shoot_number; /*发射数*/
        public float shoot_inv; /*发射间隔*/
        public int distance; /*射程*/
        public int bullet_speed; /*弹道速度*/
        public string scatter; /*散射角度*/
        public float vertAngleFix; /*发射角度垂直方向修正*/
        public int skill; /*技能ID*/
        public string special_effect; /*特殊效果*/
    }
    public IDictionary<int, o_config_RightWeaponData> o_config_RightWeaponData_map;
    void init_config_RightWeaponData(string path)
    {
        o_config_RightWeaponData_map = new Dictionary<int, o_config_RightWeaponData>();

        XmlDocument doc =  _xmlloader(path, "RightWeaponData");
        XmlNode root = doc.SelectSingleNode("root");

        XmlNode node = root.FirstChild;
        while(null != node)
        {
            o_config_RightWeaponData o = new o_config_RightWeaponData();
            o.id = (int)float.Parse(node.Attributes["id"].Value);
            o.name = node.Attributes["name"].Value;
            o.sort = (int)float.Parse(node.Attributes["sort"].Value);
            o.prefab = node.Attributes["prefab"].Value;
            o.icon = node.Attributes["icon"].Value;
            o.price = (int)float.Parse(node.Attributes["price"].Value);
            o.dps = (int)float.Parse(node.Attributes["dps"].Value);
            o.bullet = (int)float.Parse(node.Attributes["bullet"].Value);
            o.shoot_number = (int)float.Parse(node.Attributes["shoot_number"].Value);
            o.shoot_inv = float.Parse(node.Attributes["shoot_inv"].Value);
            o.distance = (int)float.Parse(node.Attributes["distance"].Value);
            o.bullet_speed = (int)float.Parse(node.Attributes["bullet_speed"].Value);
            o.scatter = node.Attributes["scatter"].Value;
            o.vertAngleFix = float.Parse(node.Attributes["vertAngleFix"].Value);
            o.skill = (int)float.Parse(node.Attributes["skill"].Value);
            o.special_effect = node.Attributes["special_effect"].Value;

            o_config_RightWeaponData_map.Add(o.id, o);
            node = node.NextSibling;
        }
    }
    //SignData.xls
    public class o_config_SignData
    {
        public int id; /*id*/
        public string day; /*天数*/
        public oCommonReward reward_list; /*奖励*/
    }
    public IDictionary<int, o_config_SignData> o_config_SignData_map;
    void init_config_SignData(string path)
    {
        o_config_SignData_map = new Dictionary<int, o_config_SignData>();

        XmlDocument doc =  _xmlloader(path, "SignData");
        XmlNode root = doc.SelectSingleNode("root");

        XmlNode node = root.FirstChild;
        while(null != node)
        {
            o_config_SignData o = new o_config_SignData();
            o.id = (int)float.Parse(node.Attributes["id"].Value);
            o.day = node.Attributes["day"].Value;
            string[] reward_list_values = node.Attributes["reward_list"].Value.Split(',');
            o.reward_list = new oCommonReward(
                (int)float.Parse(reward_list_values[0]),
                (int)float.Parse(reward_list_values[1]),
                (int)float.Parse(reward_list_values[2])
            );

            o_config_SignData_map.Add(o.id, o);
            node = node.NextSibling;
        }
    }
    //SkillData.xls
    public class o_config_SkillData
    {
        public int id; /*技能ID*/
        public string name; /*名称*/
        public string icon; /*技能图标*/
        public int skillType; /*技能类型
0：武器技能
1：召唤单位
2：施加技能效果
3：BUFF*/
        public int bindId; /*绑定id
武器技能<不用填>
召唤单位<SmallMechaData>
施加技能效果<SkillEffectData>
BUFF<BuffData>*/
        public int targetType; /*技能效果、BUFF技能的作用对象类型。
0：自身
1：自身+周围一定范围*/
        public int value; /*技能数值（伤害，提升百分比）*/
        public int range; /*效果范围*/
        public int time_casting; /*技能持续时长（秒）*/
        public int time_cd; /*技能冷却时间（秒）*/
        public string effect; /*效果*/
        public string sound_effect; /*音效*/
    }
    public IDictionary<int, o_config_SkillData> o_config_SkillData_map;
    void init_config_SkillData(string path)
    {
        o_config_SkillData_map = new Dictionary<int, o_config_SkillData>();

        XmlDocument doc =  _xmlloader(path, "SkillData");
        XmlNode root = doc.SelectSingleNode("root");

        XmlNode node = root.FirstChild;
        while(null != node)
        {
            o_config_SkillData o = new o_config_SkillData();
            o.id = (int)float.Parse(node.Attributes["id"].Value);
            o.name = node.Attributes["name"].Value;
            o.icon = node.Attributes["icon"].Value;
            o.skillType = (int)float.Parse(node.Attributes["skillType"].Value);
            o.bindId = (int)float.Parse(node.Attributes["bindId"].Value);
            o.targetType = (int)float.Parse(node.Attributes["targetType"].Value);
            o.value = (int)float.Parse(node.Attributes["value"].Value);
            o.range = (int)float.Parse(node.Attributes["range"].Value);
            o.time_casting = (int)float.Parse(node.Attributes["time_casting"].Value);
            o.time_cd = (int)float.Parse(node.Attributes["time_cd"].Value);
            o.effect = node.Attributes["effect"].Value;
            o.sound_effect = node.Attributes["sound_effect"].Value;

            o_config_SkillData_map.Add(o.id, o);
            node = node.NextSibling;
        }
    }
    //SkillEffectData.xls
    public class o_config_SkillEffectData
    {
        public int id; /*ID*/
        public string name; /*名称*/
        public string effName; /*特效名称*/
        public int jointId; /*作用节点
0：主武器
1：右手武器
2：近战武器
3：特殊武器
4：引擎
5：辅助装置
6：炮塔
7：装甲
100：主体中心
101：脚底*/
    }
    public IDictionary<int, o_config_SkillEffectData> o_config_SkillEffectData_map;
    void init_config_SkillEffectData(string path)
    {
        o_config_SkillEffectData_map = new Dictionary<int, o_config_SkillEffectData>();

        XmlDocument doc =  _xmlloader(path, "SkillEffectData");
        XmlNode root = doc.SelectSingleNode("root");

        XmlNode node = root.FirstChild;
        while(null != node)
        {
            o_config_SkillEffectData o = new o_config_SkillEffectData();
            o.id = (int)float.Parse(node.Attributes["id"].Value);
            o.name = node.Attributes["name"].Value;
            o.effName = node.Attributes["effName"].Value;
            o.jointId = (int)float.Parse(node.Attributes["jointId"].Value);

            o_config_SkillEffectData_map.Add(o.id, o);
            node = node.NextSibling;
        }
    }
    //SmallMechaData.xls
    public class o_config_SmallMechaData
    {
        public int id; /*机甲ID*/
        public int icon; /*机甲图标*/
        public string name; /*名称*/
        public string describe; /*描述*/
        public string prefab; /*预制*/
        public int type; /*类型
0：岗哨*/
        public int mainWpn; /*主武器id*/
        public int exp; /*经验*/
        public int life; /*生命*/
        public int speed; /*速度*/
        public float bodyRange; /*体积范围*/
        public float height; /*高度*/
    }
    public IDictionary<int, o_config_SmallMechaData> o_config_SmallMechaData_map;
    void init_config_SmallMechaData(string path)
    {
        o_config_SmallMechaData_map = new Dictionary<int, o_config_SmallMechaData>();

        XmlDocument doc =  _xmlloader(path, "SmallMechaData");
        XmlNode root = doc.SelectSingleNode("root");

        XmlNode node = root.FirstChild;
        while(null != node)
        {
            o_config_SmallMechaData o = new o_config_SmallMechaData();
            o.id = (int)float.Parse(node.Attributes["id"].Value);
            o.icon = (int)float.Parse(node.Attributes["icon"].Value);
            o.name = node.Attributes["name"].Value;
            o.describe = node.Attributes["describe"].Value;
            o.prefab = node.Attributes["prefab"].Value;
            o.type = (int)float.Parse(node.Attributes["type"].Value);
            o.mainWpn = (int)float.Parse(node.Attributes["mainWpn"].Value);
            o.exp = (int)float.Parse(node.Attributes["exp"].Value);
            o.life = (int)float.Parse(node.Attributes["life"].Value);
            o.speed = (int)float.Parse(node.Attributes["speed"].Value);
            o.bodyRange = float.Parse(node.Attributes["bodyRange"].Value);
            o.height = float.Parse(node.Attributes["height"].Value);

            o_config_SmallMechaData_map.Add(o.id, o);
            node = node.NextSibling;
        }
    }
    //SpecialWeaponData.xls
    public class o_config_SpecialWeaponData
    {
        public int id; /*ID*/
        public string name; /*名称*/
        public int price; /*价格*/
        public int dps; /*伤害*/
        public int range; /*伤害半径*/
        public int distance; /*射程*/
        public int skill; /*技能ID*/
    }
    public IDictionary<int, o_config_SpecialWeaponData> o_config_SpecialWeaponData_map;
    void init_config_SpecialWeaponData(string path)
    {
        o_config_SpecialWeaponData_map = new Dictionary<int, o_config_SpecialWeaponData>();

        XmlDocument doc =  _xmlloader(path, "SpecialWeaponData");
        XmlNode root = doc.SelectSingleNode("root");

        XmlNode node = root.FirstChild;
        while(null != node)
        {
            o_config_SpecialWeaponData o = new o_config_SpecialWeaponData();
            o.id = (int)float.Parse(node.Attributes["id"].Value);
            o.name = node.Attributes["name"].Value;
            o.price = (int)float.Parse(node.Attributes["price"].Value);
            o.dps = (int)float.Parse(node.Attributes["dps"].Value);
            o.range = (int)float.Parse(node.Attributes["range"].Value);
            o.distance = (int)float.Parse(node.Attributes["distance"].Value);
            o.skill = (int)float.Parse(node.Attributes["skill"].Value);

            o_config_SpecialWeaponData_map.Add(o.id, o);
            node = node.NextSibling;
        }
    }
    //TalentData.xls
    public class o_config_TalentData
    {
        public int id; /*天赋ID*/
        public int icon; /*天赋图标*/
        public int point; /*激活所需技能点数*/
        public string effect; /*效果*/
    }
    public IDictionary<int, o_config_TalentData> o_config_TalentData_map;
    void init_config_TalentData(string path)
    {
        o_config_TalentData_map = new Dictionary<int, o_config_TalentData>();

        XmlDocument doc =  _xmlloader(path, "TalentData");
        XmlNode root = doc.SelectSingleNode("root");

        XmlNode node = root.FirstChild;
        while(null != node)
        {
            o_config_TalentData o = new o_config_TalentData();
            o.id = (int)float.Parse(node.Attributes["id"].Value);
            o.icon = (int)float.Parse(node.Attributes["icon"].Value);
            o.point = (int)float.Parse(node.Attributes["point"].Value);
            o.effect = node.Attributes["effect"].Value;

            o_config_TalentData_map.Add(o.id, o);
            node = node.NextSibling;
        }
    }
    //TaskData.xls
    public class o_config_TaskData
    {
        public int id; /*id*/
        public TaskType type; /*任务类型*/
        public int param_list; /*任务参数*/
        public oCommonReward reward_list; /*任务奖励*/
        public string description; /*任务描述*/
    }
    public IDictionary<int, o_config_TaskData> o_config_TaskData_map;
    void init_config_TaskData(string path)
    {
        o_config_TaskData_map = new Dictionary<int, o_config_TaskData>();

        XmlDocument doc =  _xmlloader(path, "TaskData");
        XmlNode root = doc.SelectSingleNode("root");

        XmlNode node = root.FirstChild;
        while(null != node)
        {
            o_config_TaskData o = new o_config_TaskData();
            o.id = (int)float.Parse(node.Attributes["id"].Value);
            o.type = (TaskType)(int)float.Parse(node.Attributes["type"].Value);
            o.param_list = (int)float.Parse(node.Attributes["param_list"].Value);
            string[] reward_list_values = node.Attributes["reward_list"].Value.Split(',');
            o.reward_list = new oCommonReward(
                (int)float.Parse(reward_list_values[0]),
                (int)float.Parse(reward_list_values[1]),
                (int)float.Parse(reward_list_values[2])
            );
            o.description = node.Attributes["description"].Value;

            o_config_TaskData_map.Add(o.id, o);
            node = node.NextSibling;
        }
    }
    //TaskLimitData.xls
    public class o_config_TaskLimitData
    {
        public int id; /*id*/
        public TaskType type; /*任务类型*/
        public IList<int> param_list;/*任务参数*/
        public string description; /*任务描述*/
        public int exp; /*任务经验*/
    }
    public IDictionary<int, o_config_TaskLimitData> o_config_TaskLimitData_map;
    void init_config_TaskLimitData(string path)
    {
        o_config_TaskLimitData_map = new Dictionary<int, o_config_TaskLimitData>();

        XmlDocument doc =  _xmlloader(path, "TaskLimitData");
        XmlNode root = doc.SelectSingleNode("root");

        XmlNode node = root.FirstChild;
        while(null != node)
        {
            o_config_TaskLimitData o = new o_config_TaskLimitData();
            o.id = (int)float.Parse(node.Attributes["id"].Value);
            o.type = (TaskType)(int)float.Parse(node.Attributes["type"].Value);

            o.param_list = new List<int>();
            string[] param_list_values = node.Attributes["param_list"].Value.Split(';');
            for (int i = 0; i < param_list_values.Length; i++)
            {
                int oo = (int)float.Parse(param_list_values[i]);

                o.param_list.Add(oo);
            }
            o.description = node.Attributes["description"].Value;
            o.exp = (int)float.Parse(node.Attributes["exp"].Value);

            o_config_TaskLimitData_map.Add(o.id, o);
            node = node.NextSibling;
        }
    }
    //TurretData.xls
    public class o_config_TurretData
    {
        public int id; /*ID*/
        public string name; /*名称*/
        public int sort; /*排序*/
        public string prefab; /*预制*/
        public string icon; /*图标*/
        public int price; /*价格*/
        public int skill; /*技能ID*/
        public string effect; /*效果*/
    }
    public IDictionary<int, o_config_TurretData> o_config_TurretData_map;
    void init_config_TurretData(string path)
    {
        o_config_TurretData_map = new Dictionary<int, o_config_TurretData>();

        XmlDocument doc =  _xmlloader(path, "TurretData");
        XmlNode root = doc.SelectSingleNode("root");

        XmlNode node = root.FirstChild;
        while(null != node)
        {
            o_config_TurretData o = new o_config_TurretData();
            o.id = (int)float.Parse(node.Attributes["id"].Value);
            o.name = node.Attributes["name"].Value;
            o.sort = (int)float.Parse(node.Attributes["sort"].Value);
            o.prefab = node.Attributes["prefab"].Value;
            o.icon = node.Attributes["icon"].Value;
            o.price = (int)float.Parse(node.Attributes["price"].Value);
            o.skill = (int)float.Parse(node.Attributes["skill"].Value);
            o.effect = node.Attributes["effect"].Value;

            o_config_TurretData_map.Add(o.id, o);
            node = node.NextSibling;
        }
    }
    public delegate XmlDocument dlgt_xml_load(string path, string name);
    dlgt_xml_load _xmlloader;

    public AutoConfig(string path, dlgt_xml_load fun)
    {
        _xmlloader = fun;

        init_config_ArmorData(path);
        init_config_BuffData(path);
        init_config_BulletData(path);
        init_config_CoinData(path);
        init_config_EngineData(path);
        init_config_EquipmentData(path);
        init_config_FreeCoinData(path);
        init_config_LevelData(path);
        init_config_LotteryData(path);
        init_config_MaskData(path);
        init_config_MechaData(path);
        init_config_MechColorData(path);
        init_config_MeleeWeaponData(path);
        init_config_OpenChestData(path);
        init_config_PrimaryWeaponData(path);
        init_config_RandomData(path);
        init_config_RankData(path);
        init_config_RightWeaponData(path);
        init_config_SignData(path);
        init_config_SkillData(path);
        init_config_SkillEffectData(path);
        init_config_SmallMechaData(path);
        init_config_SpecialWeaponData(path);
        init_config_TalentData(path);
        init_config_TaskData(path);
        init_config_TaskLimitData(path);
        init_config_TurretData(path);
    }
};
