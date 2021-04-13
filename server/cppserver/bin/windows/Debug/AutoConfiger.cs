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
        up = 0, /*��*/
        down = 1, /*��*/
        left = 2, /*��*/
        right = 3, /*��*/
    };

    /**/
    public enum RewardType
    {
        coin = 0, /*���*/
        mecha = 1, /*����*/
        primaryWeapon = 2, /*������*/
        rightWeapon = 3, /*��������*/
        equipment = 4, /*����װ��*/
        armor = 5, /*װ��*/
    };

    /**/
    public enum TaskType
    {
        killMech = 0, /*��ɱ��������*/
        signed = 1, /*����ǩ������*/
        watchAD = 2, /*��������*/
        playGames = 3, /*����Ϸ����*/
        flagMode = 4, /*����ģʽʤ������*/
        pointMode = 5, /*���Ƶ�ģʽʤ������*/
        bombMode = 6, /*����ը��ģʽʤ������*/
    };

    //structs.xls

    /**/
    public class oChestItem
    {
        /*Ȩ��*/
        public readonly int _weight;
        /*��������(0:��ң�1:���ף�2:��������3:����������4:����װ����5:װ��)*/
        public readonly int _type;
        /*���ײ���id��-1�Ǵ������-2�����δӵ�С�����ǽ�ң�������*/
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
        /*��������(0:��ң�1:���ף�2:��������3:����������4:����װ����5:װ��)*/
        public readonly int _type;
        /*����ID*/
        public readonly int _id;
        /*��������*/
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
        /*����*/
        public readonly int _type;
        /*id*/
        public readonly int _id;
        /*����*/
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
        /*����id*/
        public readonly int _id;
        /*ai����*/
        public readonly int _ai_type;
        /*��������*/
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
        /*��������(0:��ң�1:���ף�2:��������3:����������4:����װ����5:װ��)*/
        public readonly int _type;
        /*����ID*/
        public readonly int _id;
        /*��������*/
        public readonly int _num;
        /*���辭��*/
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
        /*x����*/
        public readonly float _x;
        /*y����*/
        public readonly float _y;
        /*z����*/
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
        public string name; /*����*/
        public int sort; /*����*/
        public string prefab; /*Ԥ��*/
        public string icon; /*ͼ��*/
        public int price; /*�۸�*/
        public int life; /*����*/
        public int skill; /*����ID*/
        public string effect; /*����Ч��*/
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
        public string name; /*����*/
        public int canOverlying; /*�Ƿ�ɵ���*/
        public string effName; /*��Ч����*/
        public int jointId; /*���ýڵ�
0��������
1����������
2����ս����
3����������
4������
5������װ��
6������
7��װ��
100����������
101���ŵ�*/
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
        public string name; /*����*/
        public int type; /*����
0:�ӵ�
1��������Ӱ����ڵ�*/
        public float reboundParam; /*����ϵ��*/
        public int isExplosion; /*�Ƿ�ը*/
        public int isExplosion_hit; /*��ײ���Ƿ�ը���Ǳ�ը�������У�*/
        public int explosionRange; /*��ը�˺��뾶*/
        public string prefab; /*Ԥ��*/
        public string emissiveColor; /*�Է�����ɫ*/
        public int emissiveScale; /*�Է���ǿ��*/
        public string eff_hit; /*�����Ч*/
        public string eff_explosion; /*��ը��Ч*/
        public float explosionScale; /*��ը��Ч����*/
        public string eff_trail; /*��β��Ч*/
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
        public string name; /*����*/
        public string icon; /*ͼ��*/
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
        public string name; /*����*/
        public int sort; /*����*/
        public string prefab; /*Ԥ��*/
        public string icon; /*ͼ��*/
        public int price; /*�۸�*/
        public int skill; /*����ID*/
        public string effect; /*����Ч��*/
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
        public string name; /*����*/
        public int sort; /*����*/
        public string prefab; /*Ԥ��*/
        public string icon; /*ͼ��*/
        public int price; /*�۸�*/
        public int skill; /*����ID*/
        public string effect; /*����Ч��*/
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
        public int number; /*����*/
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
        public string name; /*����*/
        public string prefabName; /*Ԥ����*/
        public string sdfName; /*sdf��Դ��*/
        public float baseHeight; /*��׼����߶�*/
        public int gameMode; /*��Ϸģʽ
0������
1��ռ��
2������*/
        public string weapons; /*����*/
        public IList<oMech> smallmech;/*�з�С������*/
        public int baseAward; /*�ؿ���������*/
        public int unlockMech; /*����С��ID*/
        public int isTeaching; /*�Ƿ��ǽ�ѧ��
0��û�н�ѧ
1���н�ѧ*/
        public float enemyRebornInv; /*���˸�����*/
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
        public oCommonReward reward_list; /*����*/
        public int weight; /*Ȩ��*/
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
        public string name; /*����*/
        public int sort; /*����*/
        public string prefab; /*Ԥ��*/
        public string icon; /*ͼ��*/
        public int price; /*�۸�*/
        public int life; /*����*/
        public int speed; /*�ٶ�*/
        public string effect; /*����Ч��*/
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
        public int id; /*����ID*/
        public string name; /*��������*/
        public int sort; /*����*/
        public string prefab; /*Ԥ��*/
        public int type; /*����
0�����
1���ӱ�
2������*/
        public int bodyType; /*��������
0��˫��ʽ
1����ʽ
2������ʽ
3��Ыʽ
4���ߴ�ʽ
5:̹��ʽ*/
        public string icon; /*ͼ��*/
        public string describe; /*����*/
        public int price; /*�۸�0��ʾ��װ����*/
        public float bodyRange; /*�����Χ*/
        public int hpBase; /*����Ѫ��*/
        public int spdBase; /*�����ٶ�*/
        public int dmgPmBase; /*�����˺�ǧ�ֱ�*/
        public int expBase; /*�����������*/
        public int hpInc; /*Ѫ������*/
        public int spdInc; /*�ٶ�����*/
        public int dmgPmInc; /*�˺�ǧ�ֱ�����*/
        public int expInc; /*�����������*/
        public int init_weapon; /*��ʼ����*/
        public int init_color; /*��ʼ��ɫ*/
        public string texName; /*Ĭ����ͼ��*/
        public string blueTexName; /*��ɫ��ͼ��
(���ӱ���Ч)*/
        public string redTexName; /*��ɫ��ͼ��
(���ӱ���Ч)*/
        public string primary_weapon; /*����������*/
        public string second_weapon; /*����������*/
        public string right_weapon; /*������������*/
        public string melee_weapon; /*��ս��������*/
        public string special_weapon; /*������������*/
        public string tuffet; /*��������*/
        public string mask; /*�������*/
        public string armor; /*װ������*/
        public string equipment; /*����װ��*/
        public string engine; /*����*/
        public int summonedAiType; /*��Ϊ�ٻ���λ��AI����
0��սʿ
1������
2������
3������*/
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
        public string name; /*����*/
        public float widthRatio; /*�����ռ��ͼ����*/
        public float heightRatio; /*�߶���ռ��ͼ����*/
        public float offsetX; /*��ȡ��ʼ��ƫ��X*/
        public float offsetY; /*��ȡ��ʼ��ƫ��Y*/
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
        public string name; /*����*/
        public int sort; /*����*/
        public string prefab; /*Ԥ��*/
        public string icon; /*ͼ��*/
        public int price; /*�۸�*/
        public int dps; /*�˺�*/
        public int skill; /*����ID*/
        public string sound_effect; /*��Ч*/
        public string special_effect; /*����Ч��*/
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
        public string name; /*����*/
        public oChestItem obj1; /*���1*/
        public oChestItem obj2; /*���2*/
        public oChestItem obj3; /*���3*/
        public oChestItem obj4; /*���4*/
        public oChestItem obj5; /*���5*/
        public oChestItem obj6; /*���6*/
        public oChestItem obj7; /*���7*/
        public oChestItem obj8; /*���8*/
        public oChestItem obj9; /*���9*/
        public oChestItem obj10; /*���10*/
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
        public int id; /*���*/
        public string name; /*����*/
        public int sort; /*����*/
        public string prefab; /*Ԥ��*/
        public string icon; /*ͼ��*/
        public int price; /*�۸�*/
        public int snipeMode; /*�Ƿ��оѻ�ģʽ
0��û��
1����*/
        public int attackType; /*��������
0��������е���
1������֡�˺�
2�������˺�
3�������˺�*/
        public int attackPerMin; /*ÿ���ӹ�������*/
        public int dps; /*ÿ���˺�*/
        public int bullet; /*�ڵ�ID*/
        public int shoot_number; /*ÿ�η�����ӵ���*/
        public int distance; /*���*/
        public int bullet_speed; /*�����ٶ�*/
        public string scatter; /*ɢ��Ƕ�*/
        public float vertAngleFix; /*����Ƕȴ�ֱ��������*/
        public string effectName; /*�����Ч��*/
        public string aniName; /*���Ŷ�����*/
        public int dmgAreaType; /*�˺���������
0��������ΪԲ�ĵ�Բ����������ն�ࣩ
1��ǰ�����Σ������ࣩ
2��ǰ��׶�Σ������������ࣩ
����뾶����̾���*/
        public float rayWidth; /*�������������*/
        public float heat_quantity; /*����������0��ʾû�й������ƣ�*/
        public string special_effect; /*����Ч��*/
        public string sound_effect; /*��Ч*/
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
        public oCommonReward reward_list; /*����*/
        public int weight; /*Ȩ��*/
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
        public string name; /*��������*/
        public int exp; /*����*/
        public int getPoint; /*��ü��ܵ���*/
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
        public int id; /*���*/
        public string name; /*����*/
        public int sort; /*����*/
        public string prefab; /*Ԥ��*/
        public string icon; /*ͼ��*/
        public int price; /*�۸�*/
        public int dps; /*�˺�*/
        public int bullet; /*�ڵ�ID*/
        public int shoot_number; /*������*/
        public float shoot_inv; /*������*/
        public int distance; /*���*/
        public int bullet_speed; /*�����ٶ�*/
        public string scatter; /*ɢ��Ƕ�*/
        public float vertAngleFix; /*����Ƕȴ�ֱ��������*/
        public int skill; /*����ID*/
        public string special_effect; /*����Ч��*/
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
        public string day; /*����*/
        public oCommonReward reward_list; /*����*/
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
        public int id; /*����ID*/
        public string name; /*����*/
        public string icon; /*����ͼ��*/
        public int skillType; /*��������
0����������
1���ٻ���λ
2��ʩ�Ӽ���Ч��
3��BUFF*/
        public int bindId; /*��id
��������<������>
�ٻ���λ<SmallMechaData>
ʩ�Ӽ���Ч��<SkillEffectData>
BUFF<BuffData>*/
        public int targetType; /*����Ч����BUFF���ܵ����ö������͡�
0������
1������+��Χһ����Χ*/
        public int value; /*������ֵ���˺��������ٷֱȣ�*/
        public int range; /*Ч����Χ*/
        public int time_casting; /*���ܳ���ʱ�����룩*/
        public int time_cd; /*������ȴʱ�䣨�룩*/
        public string effect; /*Ч��*/
        public string sound_effect; /*��Ч*/
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
        public string name; /*����*/
        public string effName; /*��Ч����*/
        public int jointId; /*���ýڵ�
0��������
1����������
2����ս����
3����������
4������
5������װ��
6������
7��װ��
100����������
101���ŵ�*/
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
        public int id; /*����ID*/
        public int icon; /*����ͼ��*/
        public string name; /*����*/
        public string describe; /*����*/
        public string prefab; /*Ԥ��*/
        public int type; /*����
0������*/
        public int mainWpn; /*������id*/
        public int exp; /*����*/
        public int life; /*����*/
        public int speed; /*�ٶ�*/
        public float bodyRange; /*�����Χ*/
        public float height; /*�߶�*/
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
        public string name; /*����*/
        public int price; /*�۸�*/
        public int dps; /*�˺�*/
        public int range; /*�˺��뾶*/
        public int distance; /*���*/
        public int skill; /*����ID*/
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
        public int id; /*�츳ID*/
        public int icon; /*�츳ͼ��*/
        public int point; /*�������輼�ܵ���*/
        public string effect; /*Ч��*/
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
        public TaskType type; /*��������*/
        public int param_list; /*�������*/
        public oCommonReward reward_list; /*������*/
        public string description; /*��������*/
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
        public TaskType type; /*��������*/
        public IList<int> param_list;/*�������*/
        public string description; /*��������*/
        public int exp; /*������*/
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
        public string name; /*����*/
        public int sort; /*����*/
        public string prefab; /*Ԥ��*/
        public string icon; /*ͼ��*/
        public int price; /*�۸�*/
        public int skill; /*����ID*/
        public string effect; /*Ч��*/
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
