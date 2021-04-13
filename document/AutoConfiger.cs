using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml;

public class AutoConfig
{
    //enums.xls

    /*�ص�ö��*/
    public enum eBuilding
    {
        department_store = 1, /*1.�������ٻ�*/
        tiananmen = 2, /*2.�찲��*/
        imperial_palace = 3, /*3.�ʹ�*/
        birds_nest = 4, /*4.��*/
        water_cube = 5, /*5.ˮ����*/
        national_theater = 6, /*6.���Ҵ��Ժ*/
        taiguli = 7, /*7.������̫����*/
        quanjude = 8, /*8.ȫ�۵£�ǰ�ŵ꣩*/
        CCTV_headquarters = 9, /*9.�������̨�ܲ���¥*/
        airport = 10, /*10.�����׶�����*/
        peking_university = 11, /*11.������ѧ*/
    };

    /*��������*/
    public enum eCarType
    {
        car = 1, /*�γ�*/
        bigcar = 2, /*����*/
        rock = 3, /*���⳵*/
    };

    /*������������*/
    public enum eMissionLimitType
    {
        fragile_articles = 1, /*����Ʒ*/
        mission_time = 2, /*����ʱ�����������*/
        estimated_time = 3, /*Ԥ��ʱ�����������*/
    };

    /*��������*/
    public enum eMissionType
    {
        main_task = 1, /*��������*/
        side_task = 2, /*֧������*/
    };

    /*�����������*/
    public enum eMissionUnlockType
    {
        car_unlock = 1, /*��������*/
        mission_unlocl = 2, /*�������*/
        initial_task = 3, /*��ʼ����*/
    };

    /*����*/
    public enum eRewardType
    {
        exp = 1, /*����*/
        money = 2, /*��Ǯ*/
    };

    //structs.xls

    /*����*/
    public class oCar
    {
        /*���*/
        public int id;
        /*����*/
        public string name;
        /*�ٶ�*/
        public float speed;
        /*����ٶ�*/
        public float max_spped;
        /*��Ǯ*/
        public float cash;
    };
    /*è��*/
    public class oCat
    {
        /*����*/
        public string name;
        /*�ȼ�*/
        public int level;
        /*����*/
        public int exp;
    };
    //car.xls
    public class o_config_car
    {
        public int id; /*id*/
        public int car_type; /*����
1.�γ�
2.����
3.���⳵*/
        public int language_id; /*language��id*/
        public string language; /*language��ע*/
        public int car_unlock_id; /*������������id*/
        public int unlock_level; /*�����ȼ�*/
        public int unlock_cost; /*��������*/
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
        public string chinese; /*����*/
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
        public int city_type; /*��������
1.����*/
        public int city_building; /*�����ڽ���
1.�������ٻ�
2.�찲��
3.�ʹ�
4.��
5.ˮ����
6.���Ҵ��Ժ
7.������̫����
8.ȫ�۵£�ǰ�ŵ꣩
9.�������̨�ܲ���¥
10.�����׶�����
11.������ѧ*/
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
        public eMissionType mission_type; /*��������
1.��������
2.֧������*/
        public eMissionUnlockType mission_unlock_type; /*�����������
1.��������
2.�������
3.��ʼ����*/
        public int last_id; /*������һ��id*/
        public int next_id; /*������һ��id*/
        public ISet<int> unlock_id;/*�������id*/
        public int language_id; /*language��id*/
        public string language; /*language��ע*/
        public eMissionLimitType mission_limit_type; /*������������
1.����Ʒ
2.����ʱ�����������
3.Ԥ��ʱ�����������*/
        public eCarType mission_use_car_type; /*����ʹ�ó�������
1.�γ�
2.����
3.���⳵*/
        public int mission_origin; /*������ʼ��
map_id*/
        public int mission_destination; /*����Ŀ�ĵ�
map_id*/
        public int estimated_time; /*Ԥ��ʱ��*/
        public int mission_time; /*����ʱ��*/
        public eRewardType reward_numbre; /*����id
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
        public eRewardType reward_type; /*����
1.����
2.��Ǯ*/
        public int raward_numbre; /*��ֵ*/
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
