using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml;

public class AutoConfig
{
    //enums.xls

    /*地点枚举*/
    public enum eBuilding
    {
        department_store = 1, /*1.王府井百货*/
        tiananmen = 2, /*2.天安门*/
        imperial_palace = 3, /*3.故宫*/
        birds_nest = 4, /*4.鸟巢*/
        water_cube = 5, /*5.水立方*/
        national_theater = 6, /*6.国家大剧院*/
        taiguli = 7, /*7.三里屯太古里*/
        quanjude = 8, /*8.全聚德（前门店）*/
        CCTV_headquarters = 9, /*9.中央电视台总部大楼*/
        airport = 10, /*10.北京首都机场*/
        peking_university = 11, /*11.北京大学*/
    };

    /*汽车类型*/
    public enum eCarType
    {
        car = 1, /*轿车*/
        bigcar = 2, /*卡车*/
        rock = 3, /*出租车*/
    };

    /*任务限制类型*/
    public enum eMissionLimitType
    {
        fragile_articles = 1, /*易碎品*/
        mission_time = 2, /*任务时间内完成任务*/
        estimated_time = 3, /*预计时间内完成任务*/
    };

    /*任务类型*/
    public enum eMissionType
    {
        main_task = 1, /*主线任务*/
        side_task = 2, /*支线任务*/
    };

    /*任务解锁类型*/
    public enum eMissionUnlockType
    {
        car_unlock = 1, /*车辆解锁*/
        mission_unlocl = 2, /*任务解锁*/
        initial_task = 3, /*初始任务*/
    };

    /*奖励*/
    public enum eRewardType
    {
        exp = 1, /*经验*/
        money = 2, /*金钱*/
    };

    //structs.xls

    /*汽车*/
    public class oCar
    {
        /*编号*/
        public int id;
        /*名字*/
        public string name;
        /*速度*/
        public float speed;
        /*最大速度*/
        public float max_spped;
        /*金钱*/
        public float cash;
    };
    /*猫咪*/
    public class oCat
    {
        /*名字*/
        public string name;
        /*等级*/
        public int level;
        /*经验*/
        public int exp;
    };
    //car.xls
    public class o_config_car
    {
        public int id; /*id*/
        public int car_type; /*类型
1.轿车
2.卡车
3.出租车*/
        public int language_id; /*language表id*/
        public string language; /*language备注*/
        public int car_unlock_id; /*车辆解锁任务id*/
        public int unlock_level; /*解锁等级*/
        public int unlock_cost; /*解锁花费*/
    }
    public IDictionary<int, o_config_car> o_config_car_map;
    void init_config_car(string path)
    {
        o_config_car_map = new Dictionary<int, o_config_car>();

        XmlReader reader = XmlReader.Create(path + "/car.xml");
        XmlDocument doc = new XmlDocument();
        doc.Load(reader);
        XmlNode root = doc.SelectSingleNode("root");

        XmlNode node = root.FirstChild;
        while(null != node)
        {
            o_config_car o = new o_config_car();
            o.id = (int)float.Parse(node.Attributes["id"].Value);
            o.car_type = (int)float.Parse(node.Attributes["car_type"].Value);
            o.language_id = (int)float.Parse(node.Attributes["language_id"].Value);
            o.language = node.Attributes["language"].Value;
            o.car_unlock_id = (int)float.Parse(node.Attributes["car_unlock_id"].Value);
            o.unlock_level = (int)float.Parse(node.Attributes["unlock_level"].Value);
            o.unlock_cost = (int)float.Parse(node.Attributes["unlock_cost"].Value);

            o_config_car_map.Add(o.id, o);
            node = node.NextSibling;
        }
    }
    //language.xls
    public class o_config_language
    {
        public int id; /*id*/
        public string chinese; /*中文*/
    }
    public IDictionary<int, o_config_language> o_config_language_map;
    void init_config_language(string path)
    {
        o_config_language_map = new Dictionary<int, o_config_language>();

        XmlReader reader = XmlReader.Create(path + "/language.xml");
        XmlDocument doc = new XmlDocument();
        doc.Load(reader);
        XmlNode root = doc.SelectSingleNode("root");

        XmlNode node = root.FirstChild;
        while(null != node)
        {
            o_config_language o = new o_config_language();
            o.id = (int)float.Parse(node.Attributes["id"].Value);
            o.chinese = node.Attributes["chinese"].Value;

            o_config_language_map.Add(o.id, o);
            node = node.NextSibling;
        }
    }
    //map.xls
    public class o_config_map
    {
        public int id; /*id*/
        public int city_type; /*城市类型
1.北京*/
        public int city_building; /*城市内建筑
1.王府井百货
2.天安门
3.故宫
4.鸟巢
5.水立方
6.国家大剧院
7.三里屯太古里
8.全聚德（前门店）
9.中央电视台总部大楼
10.北京首都机场
11.北京大学*/
    }
    public IDictionary<int, o_config_map> o_config_map_map;
    void init_config_map(string path)
    {
        o_config_map_map = new Dictionary<int, o_config_map>();

        XmlReader reader = XmlReader.Create(path + "/map.xml");
        XmlDocument doc = new XmlDocument();
        doc.Load(reader);
        XmlNode root = doc.SelectSingleNode("root");

        XmlNode node = root.FirstChild;
        while(null != node)
        {
            o_config_map o = new o_config_map();
            o.id = (int)float.Parse(node.Attributes["id"].Value);
            o.city_type = (int)float.Parse(node.Attributes["city_type"].Value);
            o.city_building = (int)float.Parse(node.Attributes["city_building"].Value);

            o_config_map_map.Add(o.id, o);
            node = node.NextSibling;
        }
    }
    //mission.xls
    public class o_config_mission
    {
        public int id; /*id*/
        public eMissionType mission_type; /*任务类型
1.主线任务
2.支线任务*/
        public eMissionUnlockType mission_unlock_type; /*任务解锁类型
1.车辆解锁
2.任务解锁
3.初始任务*/
        public int last_id; /*任务上一个id*/
        public int next_id; /*任务下一个id*/
        public ISet<int> unlock_id;/*任务解锁id*/
        public int language_id; /*language表id*/
        public string language; /*language备注*/
        public eMissionLimitType mission_limit_type; /*任务限制类型
1.易碎品
2.任务时间内完成任务
3.预计时间内完成任务*/
        public eCarType mission_use_car_type; /*任务使用车辆类型
1.轿车
2.卡车
3.出租车*/
        public int mission_origin; /*任务起始地
map_id*/
        public int mission_destination; /*任务目的地
map_id*/
        public int estimated_time; /*预计时间*/
        public int mission_time; /*任务时间*/
        public eRewardType reward_numbre; /*奖励id
reward_id*/
    }
    public IDictionary<int, o_config_mission> o_config_mission_map;
    void init_config_mission(string path)
    {
        o_config_mission_map = new Dictionary<int, o_config_mission>();

        XmlReader reader = XmlReader.Create(path + "/mission.xml");
        XmlDocument doc = new XmlDocument();
        doc.Load(reader);
        XmlNode root = doc.SelectSingleNode("root");

        XmlNode node = root.FirstChild;
        while(null != node)
        {
            o_config_mission o = new o_config_mission();
            o.id = (int)float.Parse(node.Attributes["id"].Value);
            o.mission_type = (eMissionType)(int)float.Parse(node.Attributes["mission_type"].Value);
            o.mission_unlock_type = (eMissionUnlockType)(int)float.Parse(node.Attributes["mission_unlock_type"].Value);
            o.last_id = (int)float.Parse(node.Attributes["last_id"].Value);
            o.next_id = (int)float.Parse(node.Attributes["next_id"].Value);

            o.unlock_id = new HashSet<int>();
            string[] unlock_id_values = node.Attributes["unlock_id"].Value.Split(';');
            for(int i = 0; i<unlock_id_values.Length; i++)
            {
                o.unlock_id.Add((int)float.Parse(unlock_id_values[i]));
            }
            o.language_id = (int)float.Parse(node.Attributes["language_id"].Value);
            o.language = node.Attributes["language"].Value;
            o.mission_limit_type = (eMissionLimitType)(int)float.Parse(node.Attributes["mission_limit_type"].Value);
            o.mission_use_car_type = (eCarType)(int)float.Parse(node.Attributes["mission_use_car_type"].Value);
            o.mission_origin = (int)float.Parse(node.Attributes["mission_origin"].Value);
            o.mission_destination = (int)float.Parse(node.Attributes["mission_destination"].Value);
            o.estimated_time = (int)float.Parse(node.Attributes["estimated_time"].Value);
            o.mission_time = (int)float.Parse(node.Attributes["mission_time"].Value);
            o.reward_numbre = (eRewardType)(int)float.Parse(node.Attributes["reward_numbre"].Value);

            o_config_mission_map.Add(o.id, o);
            node = node.NextSibling;
        }
    }
    //reward.xls
    public class o_config_reward
    {
        public int id; /*id*/
        public eRewardType reward_type; /*类型
1.经验
2.金钱*/
        public int raward_numbre; /*数值*/
    }
    public IDictionary<int, o_config_reward> o_config_reward_map;
    void init_config_reward(string path)
    {
        o_config_reward_map = new Dictionary<int, o_config_reward>();

        XmlReader reader = XmlReader.Create(path + "/reward.xml");
        XmlDocument doc = new XmlDocument();
        doc.Load(reader);
        XmlNode root = doc.SelectSingleNode("root");

        XmlNode node = root.FirstChild;
        while(null != node)
        {
            o_config_reward o = new o_config_reward();
            o.id = (int)float.Parse(node.Attributes["id"].Value);
            o.reward_type = (eRewardType)(int)float.Parse(node.Attributes["reward_type"].Value);
            o.raward_numbre = (int)float.Parse(node.Attributes["raward_numbre"].Value);

            o_config_reward_map.Add(o.id, o);
            node = node.NextSibling;
        }
    }

    public AutoConfig(string path)
    {
        init_config_car(path);
        init_config_language(path);
        init_config_map(path);
        init_config_mission(path);
        init_config_reward(path);
    }
};
