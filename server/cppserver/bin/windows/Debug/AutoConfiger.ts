export namespace AutoConfig {
    //enums.xls

    /**/
    export enum Dir{
        up = 0, /*��*/
        down = 1, /*��*/
        left = 2, /*��*/
        right = 3, /*��*/
    }

    /**/
    export enum RewardType{
        coin = 0, /*���*/
        mecha = 1, /*����*/
        primaryWeapon = 2, /*������*/
        rightWeapon = 3, /*��������*/
        equipment = 4, /*����װ��*/
        armor = 5, /*װ��*/
    }

    /**/
    export enum TaskType{
        killMech = 0, /*��ɱ��������*/
        signed = 1, /*����ǩ������*/
        watchAD = 2, /*��������*/
        playGames = 3, /*����Ϸ����*/
        flagMode = 4, /*����ģʽʤ������*/
        pointMode = 5, /*���Ƶ�ģʽʤ������*/
        bombMode = 6, /*����ը��ģʽʤ������*/
    }

    //structs.xls

    /**/
    export class oChestItem {
        /*Ȩ��*/
        readonly _weight: number;
        /*��������(0:��ң�1:���ף�2:��������3:����������4:����װ����5:װ��)*/
        readonly _type: number;
        /*���ײ���id��-1�Ǵ������-2�����δӵ�С�����ǽ�ң�������*/
        readonly _param: number;
        constructor(weight: number, type: number, param: number) {
            this._weight = weight;
            this._type = type;
            this._param = param;
        }
    }
    /**/
    export class oCommonReward {
        /*��������(0:��ң�1:���ף�2:��������3:����������4:����װ����5:װ��)*/
        readonly _type: number;
        /*����ID*/
        readonly _id: number;
        /*��������*/
        readonly _num: number;
        constructor(type: number, id: number, num: number) {
            this._type = type;
            this._id = id;
            this._num = num;
        }
    }
    /*oItemInfo*/
    export class oItemInfo {
        /*����*/
        readonly _type: number;
        /*id*/
        readonly _id: number;
        /*����*/
        readonly _num: number;
        constructor(type: number, id: number, num: number) {
            this._type = type;
            this._id = id;
            this._num = num;
        }
    }
    /**/
    export class oMech {
        /*����id*/
        readonly _id: number;
        /*ai����*/
        readonly _ai_type: number;
        /*��������*/
        readonly _number: number;
        constructor(id: number, ai_type: number, number: number) {
            this._id = id;
            this._ai_type = ai_type;
            this._number = number;
        }
    }
    /**/
    export class oTaskLimitReward {
        /*��������(0:��ң�1:���ף�2:��������3:����������4:����װ����5:װ��)*/
        readonly _type: number;
        /*����ID*/
        readonly _id: number;
        /*��������*/
        readonly _num: number;
        /*���辭��*/
        readonly _exp: number;
        constructor(type: number, id: number, num: number, exp: number) {
            this._type = type;
            this._id = id;
            this._num = num;
            this._exp = exp;
        }
    }
    /**/
    export class oVec3 {
        /*x����*/
        readonly _x: number;
        /*y����*/
        readonly _y: number;
        /*z����*/
        readonly _z: number;
        constructor(x: number, y: number, z: number) {
            this._x = x;
            this._y = y;
            this._z = z;
        }
    }
    export type fun_config_file_load = (path: string, fun:fun_config_file_loaded) => void;
    export type fun_config_file_loaded = (json: object) => void;

    var expectation : number = 27;

    //ArmorData.xls
    export class o_config_ArmorData {
        readonly _id: number; /*ID*/
        readonly _name: string; /*����*/
        readonly _sort: number; /*����*/
        readonly _prefab: string; /*Ԥ��*/
        readonly _icon: string; /*ͼ��*/
        readonly _price: number; /*�۸�*/
        readonly _life: number; /*����*/
        readonly _skill: number; /*����ID*/
        readonly _effect: string; /*����Ч��*/

        constructor(id: number, name: string, sort: number, prefab: string, icon: string, price: number, life: number, skill: number, effect: string) {
            this._id = id;
            this._name = name;
            this._sort = sort;
            this._prefab = prefab;
            this._icon = icon;
            this._price = price;
            this._life = life;
            this._skill = skill;
            this._effect = effect;
        }
    }

    var o_config_ArmorData_map : Map<number, o_config_ArmorData>;
    function config_ArmorData_loaded(json: object): void {
        o_config_ArmorData_map = new Map<number, o_config_ArmorData>();

        for (let i in json['root']) {
            let id: number = parseInt(json['root'][i]["id"]);
            let name: string = json['root'][i]["name"];
            let sort: number = parseInt(json['root'][i]["sort"]);
            let prefab: string = json['root'][i]["prefab"];
            let icon: string = json['root'][i]["icon"];
            let price: number = parseInt(json['root'][i]["price"]);
            let life: number = parseInt(json['root'][i]["life"]);
            let skill: number = parseInt(json['root'][i]["skill"]);
            let effect: string = json['root'][i]["effect"];

            o_config_ArmorData_map.set(id, new o_config_ArmorData(id, name, sort, prefab, icon, price, life, skill, effect));
        }
        expectation--;
    }
    function init_config_ArmorData(path: string, fun:fun_config_file_load): void {
        fun(path + "/ArmorData.json", config_ArmorData_loaded);
    }
    //BuffData.xls
    export class o_config_BuffData {
        readonly _id: number; /*ID*/
        readonly _name: string; /*����*/
        readonly _canOverlying: number; /*�Ƿ�ɵ���*/
        readonly _effName: string; /*��Ч����*/
        readonly _jointId: number; /*���ýڵ�
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

        constructor(id: number, name: string, canOverlying: number, effName: string, jointId: number) {
            this._id = id;
            this._name = name;
            this._canOverlying = canOverlying;
            this._effName = effName;
            this._jointId = jointId;
        }
    }

    var o_config_BuffData_map : Map<number, o_config_BuffData>;
    function config_BuffData_loaded(json: object): void {
        o_config_BuffData_map = new Map<number, o_config_BuffData>();

        for (let i in json['root']) {
            let id: number = parseInt(json['root'][i]["id"]);
            let name: string = json['root'][i]["name"];
            let canOverlying: number = parseInt(json['root'][i]["canOverlying"]);
            let effName: string = json['root'][i]["effName"];
            let jointId: number = parseInt(json['root'][i]["jointId"]);

            o_config_BuffData_map.set(id, new o_config_BuffData(id, name, canOverlying, effName, jointId));
        }
        expectation--;
    }
    function init_config_BuffData(path: string, fun:fun_config_file_load): void {
        fun(path + "/BuffData.json", config_BuffData_loaded);
    }
    //BulletData.xls
    export class o_config_BulletData {
        readonly _id: number; /*ID*/
        readonly _name: string; /*����*/
        readonly _type: number; /*����
0:�ӵ�
1��������Ӱ����ڵ�*/
        readonly _reboundParam: number; /*����ϵ��*/
        readonly _isExplosion: number; /*�Ƿ�ը*/
        readonly _isExplosion_hit: number; /*��ײ���Ƿ�ը���Ǳ�ը�������У�*/
        readonly _explosionRange: number; /*��ը�˺��뾶*/
        readonly _prefab: string; /*Ԥ��*/
        readonly _emissiveColor: string; /*�Է�����ɫ*/
        readonly _emissiveScale: number; /*�Է���ǿ��*/
        readonly _eff_hit: string; /*�����Ч*/
        readonly _eff_explosion: string; /*��ը��Ч*/
        readonly _explosionScale: number; /*��ը��Ч����*/
        readonly _eff_trail: string; /*��β��Ч*/

        constructor(id: number, name: string, type: number, reboundParam: number, isExplosion: number, isExplosion_hit: number, explosionRange: number, prefab: string, emissiveColor: string, emissiveScale: number, eff_hit: string, eff_explosion: string, explosionScale: number, eff_trail: string) {
            this._id = id;
            this._name = name;
            this._type = type;
            this._reboundParam = reboundParam;
            this._isExplosion = isExplosion;
            this._isExplosion_hit = isExplosion_hit;
            this._explosionRange = explosionRange;
            this._prefab = prefab;
            this._emissiveColor = emissiveColor;
            this._emissiveScale = emissiveScale;
            this._eff_hit = eff_hit;
            this._eff_explosion = eff_explosion;
            this._explosionScale = explosionScale;
            this._eff_trail = eff_trail;
        }
    }

    var o_config_BulletData_map : Map<number, o_config_BulletData>;
    function config_BulletData_loaded(json: object): void {
        o_config_BulletData_map = new Map<number, o_config_BulletData>();

        for (let i in json['root']) {
            let id: number = parseInt(json['root'][i]["id"]);
            let name: string = json['root'][i]["name"];
            let type: number = parseInt(json['root'][i]["type"]);
            let reboundParam: number = parseFloat(json['root'][i]["reboundParam"]);
            let isExplosion: number = parseInt(json['root'][i]["isExplosion"]);
            let isExplosion_hit: number = parseInt(json['root'][i]["isExplosion_hit"]);
            let explosionRange: number = parseInt(json['root'][i]["explosionRange"]);
            let prefab: string = json['root'][i]["prefab"];
            let emissiveColor: string = json['root'][i]["emissiveColor"];
            let emissiveScale: number = parseInt(json['root'][i]["emissiveScale"]);
            let eff_hit: string = json['root'][i]["eff_hit"];
            let eff_explosion: string = json['root'][i]["eff_explosion"];
            let explosionScale: number = parseFloat(json['root'][i]["explosionScale"]);
            let eff_trail: string = json['root'][i]["eff_trail"];

            o_config_BulletData_map.set(id, new o_config_BulletData(id, name, type, reboundParam, isExplosion, isExplosion_hit, explosionRange, prefab, emissiveColor, emissiveScale, eff_hit, eff_explosion, explosionScale, eff_trail));
        }
        expectation--;
    }
    function init_config_BulletData(path: string, fun:fun_config_file_load): void {
        fun(path + "/BulletData.json", config_BulletData_loaded);
    }
    //CoinData.xls
    export class o_config_CoinData {
        readonly _id: number; /*id*/
        readonly _name: string; /*����*/
        readonly _icon: string; /*ͼ��*/

        constructor(id: number, name: string, icon: string) {
            this._id = id;
            this._name = name;
            this._icon = icon;
        }
    }

    var o_config_CoinData_map : Map<number, o_config_CoinData>;
    function config_CoinData_loaded(json: object): void {
        o_config_CoinData_map = new Map<number, o_config_CoinData>();

        for (let i in json['root']) {
            let id: number = parseInt(json['root'][i]["id"]);
            let name: string = json['root'][i]["name"];
            let icon: string = json['root'][i]["icon"];

            o_config_CoinData_map.set(id, new o_config_CoinData(id, name, icon));
        }
        expectation--;
    }
    function init_config_CoinData(path: string, fun:fun_config_file_load): void {
        fun(path + "/CoinData.json", config_CoinData_loaded);
    }
    //EngineData.xls
    export class o_config_EngineData {
        readonly _id: number; /*ID*/
        readonly _name: string; /*����*/
        readonly _sort: number; /*����*/
        readonly _prefab: string; /*Ԥ��*/
        readonly _icon: string; /*ͼ��*/
        readonly _price: number; /*�۸�*/
        readonly _skill: number; /*����ID*/
        readonly _effect: string; /*����Ч��*/

        constructor(id: number, name: string, sort: number, prefab: string, icon: string, price: number, skill: number, effect: string) {
            this._id = id;
            this._name = name;
            this._sort = sort;
            this._prefab = prefab;
            this._icon = icon;
            this._price = price;
            this._skill = skill;
            this._effect = effect;
        }
    }

    var o_config_EngineData_map : Map<number, o_config_EngineData>;
    function config_EngineData_loaded(json: object): void {
        o_config_EngineData_map = new Map<number, o_config_EngineData>();

        for (let i in json['root']) {
            let id: number = parseInt(json['root'][i]["id"]);
            let name: string = json['root'][i]["name"];
            let sort: number = parseInt(json['root'][i]["sort"]);
            let prefab: string = json['root'][i]["prefab"];
            let icon: string = json['root'][i]["icon"];
            let price: number = parseInt(json['root'][i]["price"]);
            let skill: number = parseInt(json['root'][i]["skill"]);
            let effect: string = json['root'][i]["effect"];

            o_config_EngineData_map.set(id, new o_config_EngineData(id, name, sort, prefab, icon, price, skill, effect));
        }
        expectation--;
    }
    function init_config_EngineData(path: string, fun:fun_config_file_load): void {
        fun(path + "/EngineData.json", config_EngineData_loaded);
    }
    //EquipmentData.xls
    export class o_config_EquipmentData {
        readonly _id: number; /*ID*/
        readonly _name: string; /*����*/
        readonly _sort: number; /*����*/
        readonly _prefab: string; /*Ԥ��*/
        readonly _icon: string; /*ͼ��*/
        readonly _price: number; /*�۸�*/
        readonly _skill: number; /*����ID*/
        readonly _effect: string; /*����Ч��*/

        constructor(id: number, name: string, sort: number, prefab: string, icon: string, price: number, skill: number, effect: string) {
            this._id = id;
            this._name = name;
            this._sort = sort;
            this._prefab = prefab;
            this._icon = icon;
            this._price = price;
            this._skill = skill;
            this._effect = effect;
        }
    }

    var o_config_EquipmentData_map : Map<number, o_config_EquipmentData>;
    function config_EquipmentData_loaded(json: object): void {
        o_config_EquipmentData_map = new Map<number, o_config_EquipmentData>();

        for (let i in json['root']) {
            let id: number = parseInt(json['root'][i]["id"]);
            let name: string = json['root'][i]["name"];
            let sort: number = parseInt(json['root'][i]["sort"]);
            let prefab: string = json['root'][i]["prefab"];
            let icon: string = json['root'][i]["icon"];
            let price: number = parseInt(json['root'][i]["price"]);
            let skill: number = parseInt(json['root'][i]["skill"]);
            let effect: string = json['root'][i]["effect"];

            o_config_EquipmentData_map.set(id, new o_config_EquipmentData(id, name, sort, prefab, icon, price, skill, effect));
        }
        expectation--;
    }
    function init_config_EquipmentData(path: string, fun:fun_config_file_load): void {
        fun(path + "/EquipmentData.json", config_EquipmentData_loaded);
    }
    //FreeCoinData.xls
    export class o_config_FreeCoinData {
        readonly _id: number; /*id*/
        readonly _number: number; /*����*/

        constructor(id: number, number: number) {
            this._id = id;
            this._number = number;
        }
    }

    var o_config_FreeCoinData_map : Map<number, o_config_FreeCoinData>;
    function config_FreeCoinData_loaded(json: object): void {
        o_config_FreeCoinData_map = new Map<number, o_config_FreeCoinData>();

        for (let i in json['root']) {
            let id: number = parseInt(json['root'][i]["id"]);
            let number: number = parseInt(json['root'][i]["number"]);

            o_config_FreeCoinData_map.set(id, new o_config_FreeCoinData(id, number));
        }
        expectation--;
    }
    function init_config_FreeCoinData(path: string, fun:fun_config_file_load): void {
        fun(path + "/FreeCoinData.json", config_FreeCoinData_loaded);
    }
    //LevelData.xls
    export class o_config_LevelData {
        readonly _id: number; /*id*/
        readonly _name: string; /*����*/
        readonly _prefabName: string; /*Ԥ����*/
        readonly _sdfName: string; /*sdf��Դ��*/
        readonly _baseHeight: number; /*��׼����߶�*/
        readonly _gameMode: number; /*��Ϸģʽ
0������
1��ռ��
2������*/
        readonly _weapons: string; /*����*/
        readonly _smallmech: Array<oMech>;/*�з�С������*/
        readonly _baseAward: number; /*�ؿ���������*/
        readonly _unlockMech: number; /*����С��ID*/
        readonly _isTeaching: number; /*�Ƿ��ǽ�ѧ��
0��û�н�ѧ
1���н�ѧ*/
        readonly _enemyRebornInv: number; /*���˸�����*/

        constructor(id: number, name: string, prefabName: string, sdfName: string, baseHeight: number, gameMode: number, weapons: string, smallmech: Array<oMech>, baseAward: number, unlockMech: number, isTeaching: number, enemyRebornInv: number) {
            this._id = id;
            this._name = name;
            this._prefabName = prefabName;
            this._sdfName = sdfName;
            this._baseHeight = baseHeight;
            this._gameMode = gameMode;
            this._weapons = weapons;
            this._smallmech = smallmech;
            this._baseAward = baseAward;
            this._unlockMech = unlockMech;
            this._isTeaching = isTeaching;
            this._enemyRebornInv = enemyRebornInv;
        }
    }

    var o_config_LevelData_map : Map<number, o_config_LevelData>;
    function config_LevelData_loaded(json: object): void {
        o_config_LevelData_map = new Map<number, o_config_LevelData>();

        for (let i in json['root']) {
            let id: number = parseInt(json['root'][i]["id"]);
            let name: string = json['root'][i]["name"];
            let prefabName: string = json['root'][i]["prefabName"];
            let sdfName: string = json['root'][i]["sdfName"];
            let baseHeight: number = parseFloat(json['root'][i]["baseHeight"]);
            let gameMode: number = parseInt(json['root'][i]["gameMode"]);
            let weapons: string = json['root'][i]["weapons"];

            let smallmech = new Array<oMech>();
            let  smallmech_ary = json['root'][i]["smallmech"].toString().split(';');
            for (let i = 0; i < smallmech_ary.length; i++) {
                let value_ary = smallmech_ary[i].toString().split(',');
                let id: number = parseInt(value_ary[0]);
                let ai_type: number = parseInt(value_ary[1]);
                let number: number = parseInt(value_ary[2]);

                let oo  = new oMech(id, ai_type, number);
                smallmech.push(oo);
            }
            let baseAward: number = parseInt(json['root'][i]["baseAward"]);
            let unlockMech: number = parseInt(json['root'][i]["unlockMech"]);
            let isTeaching: number = parseInt(json['root'][i]["isTeaching"]);
            let enemyRebornInv: number = parseFloat(json['root'][i]["enemyRebornInv"]);

            o_config_LevelData_map.set(id, new o_config_LevelData(id, name, prefabName, sdfName, baseHeight, gameMode, weapons, smallmech, baseAward, unlockMech, isTeaching, enemyRebornInv));
        }
        expectation--;
    }
    function init_config_LevelData(path: string, fun:fun_config_file_load): void {
        fun(path + "/LevelData.json", config_LevelData_loaded);
    }
    //LotteryData.xls
    export class o_config_LotteryData {
        readonly _id: number; /*id*/
        readonly _reward_list: oCommonReward; /*����*/
        readonly _weight: number; /*Ȩ��*/

        constructor(id: number, reward_list: oCommonReward, weight: number) {
            this._id = id;
            this._reward_list = reward_list;
            this._weight = weight;
        }
    }

    var o_config_LotteryData_map : Map<number, o_config_LotteryData>;
    function config_LotteryData_loaded(json: object): void {
        o_config_LotteryData_map = new Map<number, o_config_LotteryData>();

        for (let i in json['root']) {
            let id: number = parseInt(json['root'][i]["id"]);
            let reward_list_value = json['root'][i]["reward_list"].toString().split(',');
            let reward_list: oCommonReward = new oCommonReward(parseInt(reward_list_value[0]), parseInt(reward_list_value[1]), parseInt(reward_list_value[2]),);
            let weight: number = parseInt(json['root'][i]["weight"]);

            o_config_LotteryData_map.set(id, new o_config_LotteryData(id, reward_list, weight));
        }
        expectation--;
    }
    function init_config_LotteryData(path: string, fun:fun_config_file_load): void {
        fun(path + "/LotteryData.json", config_LotteryData_loaded);
    }
    //MaskData.xls
    export class o_config_MaskData {
        readonly _id: number; /*ID*/
        readonly _name: string; /*����*/
        readonly _sort: number; /*����*/
        readonly _prefab: string; /*Ԥ��*/
        readonly _icon: string; /*ͼ��*/
        readonly _price: number; /*�۸�*/
        readonly _life: number; /*����*/
        readonly _speed: number; /*�ٶ�*/
        readonly _effect: string; /*����Ч��*/

        constructor(id: number, name: string, sort: number, prefab: string, icon: string, price: number, life: number, speed: number, effect: string) {
            this._id = id;
            this._name = name;
            this._sort = sort;
            this._prefab = prefab;
            this._icon = icon;
            this._price = price;
            this._life = life;
            this._speed = speed;
            this._effect = effect;
        }
    }

    var o_config_MaskData_map : Map<number, o_config_MaskData>;
    function config_MaskData_loaded(json: object): void {
        o_config_MaskData_map = new Map<number, o_config_MaskData>();

        for (let i in json['root']) {
            let id: number = parseInt(json['root'][i]["id"]);
            let name: string = json['root'][i]["name"];
            let sort: number = parseInt(json['root'][i]["sort"]);
            let prefab: string = json['root'][i]["prefab"];
            let icon: string = json['root'][i]["icon"];
            let price: number = parseInt(json['root'][i]["price"]);
            let life: number = parseInt(json['root'][i]["life"]);
            let speed: number = parseInt(json['root'][i]["speed"]);
            let effect: string = json['root'][i]["effect"];

            o_config_MaskData_map.set(id, new o_config_MaskData(id, name, sort, prefab, icon, price, life, speed, effect));
        }
        expectation--;
    }
    function init_config_MaskData(path: string, fun:fun_config_file_load): void {
        fun(path + "/MaskData.json", config_MaskData_loaded);
    }
    //MechaData.xls
    export class o_config_MechaData {
        readonly _id: number; /*����ID*/
        readonly _name: string; /*��������*/
        readonly _sort: number; /*����*/
        readonly _prefab: string; /*Ԥ��*/
        readonly _type: number; /*����
0�����
1���ӱ�
2������*/
        readonly _bodyType: number; /*��������
0��˫��ʽ
1����ʽ
2������ʽ
3��Ыʽ
4���ߴ�ʽ
5:̹��ʽ*/
        readonly _icon: string; /*ͼ��*/
        readonly _describe: string; /*����*/
        readonly _price: number; /*�۸�0��ʾ��װ����*/
        readonly _bodyRange: number; /*�����Χ*/
        readonly _hpBase: number; /*����Ѫ��*/
        readonly _spdBase: number; /*�����ٶ�*/
        readonly _dmgPmBase: number; /*�����˺�ǧ�ֱ�*/
        readonly _expBase: number; /*�����������*/
        readonly _hpInc: number; /*Ѫ������*/
        readonly _spdInc: number; /*�ٶ�����*/
        readonly _dmgPmInc: number; /*�˺�ǧ�ֱ�����*/
        readonly _expInc: number; /*�����������*/
        readonly _init_weapon: number; /*��ʼ����*/
        readonly _init_color: number; /*��ʼ��ɫ*/
        readonly _texName: string; /*Ĭ����ͼ��*/
        readonly _blueTexName: string; /*��ɫ��ͼ��
(���ӱ���Ч)*/
        readonly _redTexName: string; /*��ɫ��ͼ��
(���ӱ���Ч)*/
        readonly _primary_weapon: string; /*����������*/
        readonly _second_weapon: string; /*����������*/
        readonly _right_weapon: string; /*������������*/
        readonly _melee_weapon: string; /*��ս��������*/
        readonly _special_weapon: string; /*������������*/
        readonly _tuffet: string; /*��������*/
        readonly _mask: string; /*�������*/
        readonly _armor: string; /*װ������*/
        readonly _equipment: string; /*����װ��*/
        readonly _engine: string; /*����*/
        readonly _summonedAiType: number; /*��Ϊ�ٻ���λ��AI����
0��սʿ
1������
2������
3������*/

        constructor(id: number, name: string, sort: number, prefab: string, type: number, bodyType: number, icon: string, describe: string, price: number, bodyRange: number, hpBase: number, spdBase: number, dmgPmBase: number, expBase: number, hpInc: number, spdInc: number, dmgPmInc: number, expInc: number, init_weapon: number, init_color: number, texName: string, blueTexName: string, redTexName: string, primary_weapon: string, second_weapon: string, right_weapon: string, melee_weapon: string, special_weapon: string, tuffet: string, mask: string, armor: string, equipment: string, engine: string, summonedAiType: number) {
            this._id = id;
            this._name = name;
            this._sort = sort;
            this._prefab = prefab;
            this._type = type;
            this._bodyType = bodyType;
            this._icon = icon;
            this._describe = describe;
            this._price = price;
            this._bodyRange = bodyRange;
            this._hpBase = hpBase;
            this._spdBase = spdBase;
            this._dmgPmBase = dmgPmBase;
            this._expBase = expBase;
            this._hpInc = hpInc;
            this._spdInc = spdInc;
            this._dmgPmInc = dmgPmInc;
            this._expInc = expInc;
            this._init_weapon = init_weapon;
            this._init_color = init_color;
            this._texName = texName;
            this._blueTexName = blueTexName;
            this._redTexName = redTexName;
            this._primary_weapon = primary_weapon;
            this._second_weapon = second_weapon;
            this._right_weapon = right_weapon;
            this._melee_weapon = melee_weapon;
            this._special_weapon = special_weapon;
            this._tuffet = tuffet;
            this._mask = mask;
            this._armor = armor;
            this._equipment = equipment;
            this._engine = engine;
            this._summonedAiType = summonedAiType;
        }
    }

    var o_config_MechaData_map : Map<number, o_config_MechaData>;
    function config_MechaData_loaded(json: object): void {
        o_config_MechaData_map = new Map<number, o_config_MechaData>();

        for (let i in json['root']) {
            let id: number = parseInt(json['root'][i]["id"]);
            let name: string = json['root'][i]["name"];
            let sort: number = parseInt(json['root'][i]["sort"]);
            let prefab: string = json['root'][i]["prefab"];
            let type: number = parseInt(json['root'][i]["type"]);
            let bodyType: number = parseInt(json['root'][i]["bodyType"]);
            let icon: string = json['root'][i]["icon"];
            let describe: string = json['root'][i]["describe"];
            let price: number = parseInt(json['root'][i]["price"]);
            let bodyRange: number = parseFloat(json['root'][i]["bodyRange"]);
            let hpBase: number = parseInt(json['root'][i]["hpBase"]);
            let spdBase: number = parseInt(json['root'][i]["spdBase"]);
            let dmgPmBase: number = parseInt(json['root'][i]["dmgPmBase"]);
            let expBase: number = parseInt(json['root'][i]["expBase"]);
            let hpInc: number = parseInt(json['root'][i]["hpInc"]);
            let spdInc: number = parseInt(json['root'][i]["spdInc"]);
            let dmgPmInc: number = parseInt(json['root'][i]["dmgPmInc"]);
            let expInc: number = parseInt(json['root'][i]["expInc"]);
            let init_weapon: number = parseInt(json['root'][i]["init_weapon"]);
            let init_color: number = parseInt(json['root'][i]["init_color"]);
            let texName: string = json['root'][i]["texName"];
            let blueTexName: string = json['root'][i]["blueTexName"];
            let redTexName: string = json['root'][i]["redTexName"];
            let primary_weapon: string = json['root'][i]["primary_weapon"];
            let second_weapon: string = json['root'][i]["second_weapon"];
            let right_weapon: string = json['root'][i]["right_weapon"];
            let melee_weapon: string = json['root'][i]["melee_weapon"];
            let special_weapon: string = json['root'][i]["special_weapon"];
            let tuffet: string = json['root'][i]["tuffet"];
            let mask: string = json['root'][i]["mask"];
            let armor: string = json['root'][i]["armor"];
            let equipment: string = json['root'][i]["equipment"];
            let engine: string = json['root'][i]["engine"];
            let summonedAiType: number = parseInt(json['root'][i]["summonedAiType"]);

            o_config_MechaData_map.set(id, new o_config_MechaData(id, name, sort, prefab, type, bodyType, icon, describe, price, bodyRange, hpBase, spdBase, dmgPmBase, expBase, hpInc, spdInc, dmgPmInc, expInc, init_weapon, init_color, texName, blueTexName, redTexName, primary_weapon, second_weapon, right_weapon, melee_weapon, special_weapon, tuffet, mask, armor, equipment, engine, summonedAiType));
        }
        expectation--;
    }
    function init_config_MechaData(path: string, fun:fun_config_file_load): void {
        fun(path + "/MechaData.json", config_MechaData_loaded);
    }
    //MechColorData.xls
    export class o_config_MechColorData {
        readonly _id: number; /*id*/
        readonly _name: string; /*����*/
        readonly _widthRatio: number; /*�����ռ��ͼ����*/
        readonly _heightRatio: number; /*�߶���ռ��ͼ����*/
        readonly _offsetX: number; /*��ȡ��ʼ��ƫ��X*/
        readonly _offsetY: number; /*��ȡ��ʼ��ƫ��Y*/

        constructor(id: number, name: string, widthRatio: number, heightRatio: number, offsetX: number, offsetY: number) {
            this._id = id;
            this._name = name;
            this._widthRatio = widthRatio;
            this._heightRatio = heightRatio;
            this._offsetX = offsetX;
            this._offsetY = offsetY;
        }
    }

    var o_config_MechColorData_map : Map<number, o_config_MechColorData>;
    function config_MechColorData_loaded(json: object): void {
        o_config_MechColorData_map = new Map<number, o_config_MechColorData>();

        for (let i in json['root']) {
            let id: number = parseInt(json['root'][i]["id"]);
            let name: string = json['root'][i]["name"];
            let widthRatio: number = parseFloat(json['root'][i]["widthRatio"]);
            let heightRatio: number = parseFloat(json['root'][i]["heightRatio"]);
            let offsetX: number = parseFloat(json['root'][i]["offsetX"]);
            let offsetY: number = parseFloat(json['root'][i]["offsetY"]);

            o_config_MechColorData_map.set(id, new o_config_MechColorData(id, name, widthRatio, heightRatio, offsetX, offsetY));
        }
        expectation--;
    }
    function init_config_MechColorData(path: string, fun:fun_config_file_load): void {
        fun(path + "/MechColorData.json", config_MechColorData_loaded);
    }
    //MeleeWeaponData.xls
    export class o_config_MeleeWeaponData {
        readonly _id: number; /*ID*/
        readonly _name: string; /*����*/
        readonly _sort: number; /*����*/
        readonly _prefab: string; /*Ԥ��*/
        readonly _icon: string; /*ͼ��*/
        readonly _price: number; /*�۸�*/
        readonly _dps: number; /*�˺�*/
        readonly _skill: number; /*����ID*/
        readonly _sound_effect: string; /*��Ч*/
        readonly _special_effect: string; /*����Ч��*/

        constructor(id: number, name: string, sort: number, prefab: string, icon: string, price: number, dps: number, skill: number, sound_effect: string, special_effect: string) {
            this._id = id;
            this._name = name;
            this._sort = sort;
            this._prefab = prefab;
            this._icon = icon;
            this._price = price;
            this._dps = dps;
            this._skill = skill;
            this._sound_effect = sound_effect;
            this._special_effect = special_effect;
        }
    }

    var o_config_MeleeWeaponData_map : Map<number, o_config_MeleeWeaponData>;
    function config_MeleeWeaponData_loaded(json: object): void {
        o_config_MeleeWeaponData_map = new Map<number, o_config_MeleeWeaponData>();

        for (let i in json['root']) {
            let id: number = parseInt(json['root'][i]["id"]);
            let name: string = json['root'][i]["name"];
            let sort: number = parseInt(json['root'][i]["sort"]);
            let prefab: string = json['root'][i]["prefab"];
            let icon: string = json['root'][i]["icon"];
            let price: number = parseInt(json['root'][i]["price"]);
            let dps: number = parseInt(json['root'][i]["dps"]);
            let skill: number = parseInt(json['root'][i]["skill"]);
            let sound_effect: string = json['root'][i]["sound_effect"];
            let special_effect: string = json['root'][i]["special_effect"];

            o_config_MeleeWeaponData_map.set(id, new o_config_MeleeWeaponData(id, name, sort, prefab, icon, price, dps, skill, sound_effect, special_effect));
        }
        expectation--;
    }
    function init_config_MeleeWeaponData(path: string, fun:fun_config_file_load): void {
        fun(path + "/MeleeWeaponData.json", config_MeleeWeaponData_loaded);
    }
    //OpenChestData.xls
    export class o_config_OpenChestData {
        readonly _id: number; /*ID*/
        readonly _name: string; /*����*/
        readonly _obj1: oChestItem; /*���1*/
        readonly _obj2: oChestItem; /*���2*/
        readonly _obj3: oChestItem; /*���3*/
        readonly _obj4: oChestItem; /*���4*/
        readonly _obj5: oChestItem; /*���5*/
        readonly _obj6: oChestItem; /*���6*/
        readonly _obj7: oChestItem; /*���7*/
        readonly _obj8: oChestItem; /*���8*/
        readonly _obj9: oChestItem; /*���9*/
        readonly _obj10: oChestItem; /*���10*/

        constructor(id: number, name: string, obj1: oChestItem, obj2: oChestItem, obj3: oChestItem, obj4: oChestItem, obj5: oChestItem, obj6: oChestItem, obj7: oChestItem, obj8: oChestItem, obj9: oChestItem, obj10: oChestItem) {
            this._id = id;
            this._name = name;
            this._obj1 = obj1;
            this._obj2 = obj2;
            this._obj3 = obj3;
            this._obj4 = obj4;
            this._obj5 = obj5;
            this._obj6 = obj6;
            this._obj7 = obj7;
            this._obj8 = obj8;
            this._obj9 = obj9;
            this._obj10 = obj10;
        }
    }

    var o_config_OpenChestData_map : Map<number, o_config_OpenChestData>;
    function config_OpenChestData_loaded(json: object): void {
        o_config_OpenChestData_map = new Map<number, o_config_OpenChestData>();

        for (let i in json['root']) {
            let id: number = parseInt(json['root'][i]["id"]);
            let name: string = json['root'][i]["name"];
            let obj1_value = json['root'][i]["obj1"].toString().split(',');
            let obj1: oChestItem = new oChestItem(parseInt(obj1_value[0]), parseInt(obj1_value[1]), parseInt(obj1_value[2]),);
            let obj2_value = json['root'][i]["obj2"].toString().split(',');
            let obj2: oChestItem = new oChestItem(parseInt(obj2_value[0]), parseInt(obj2_value[1]), parseInt(obj2_value[2]),);
            let obj3_value = json['root'][i]["obj3"].toString().split(',');
            let obj3: oChestItem = new oChestItem(parseInt(obj3_value[0]), parseInt(obj3_value[1]), parseInt(obj3_value[2]),);
            let obj4_value = json['root'][i]["obj4"].toString().split(',');
            let obj4: oChestItem = new oChestItem(parseInt(obj4_value[0]), parseInt(obj4_value[1]), parseInt(obj4_value[2]),);
            let obj5_value = json['root'][i]["obj5"].toString().split(',');
            let obj5: oChestItem = new oChestItem(parseInt(obj5_value[0]), parseInt(obj5_value[1]), parseInt(obj5_value[2]),);
            let obj6_value = json['root'][i]["obj6"].toString().split(',');
            let obj6: oChestItem = new oChestItem(parseInt(obj6_value[0]), parseInt(obj6_value[1]), parseInt(obj6_value[2]),);
            let obj7_value = json['root'][i]["obj7"].toString().split(',');
            let obj7: oChestItem = new oChestItem(parseInt(obj7_value[0]), parseInt(obj7_value[1]), parseInt(obj7_value[2]),);
            let obj8_value = json['root'][i]["obj8"].toString().split(',');
            let obj8: oChestItem = new oChestItem(parseInt(obj8_value[0]), parseInt(obj8_value[1]), parseInt(obj8_value[2]),);
            let obj9_value = json['root'][i]["obj9"].toString().split(',');
            let obj9: oChestItem = new oChestItem(parseInt(obj9_value[0]), parseInt(obj9_value[1]), parseInt(obj9_value[2]),);
            let obj10_value = json['root'][i]["obj10"].toString().split(',');
            let obj10: oChestItem = new oChestItem(parseInt(obj10_value[0]), parseInt(obj10_value[1]), parseInt(obj10_value[2]),);

            o_config_OpenChestData_map.set(id, new o_config_OpenChestData(id, name, obj1, obj2, obj3, obj4, obj5, obj6, obj7, obj8, obj9, obj10));
        }
        expectation--;
    }
    function init_config_OpenChestData(path: string, fun:fun_config_file_load): void {
        fun(path + "/OpenChestData.json", config_OpenChestData_loaded);
    }
    //PrimaryWeaponData.xls
    export class o_config_PrimaryWeaponData {
        readonly _id: number; /*���*/
        readonly _name: string; /*����*/
        readonly _sort: number; /*����*/
        readonly _prefab: string; /*Ԥ��*/
        readonly _icon: string; /*ͼ��*/
        readonly _price: number; /*�۸�*/
        readonly _snipeMode: number; /*�Ƿ��оѻ�ģʽ
0��û��
1����*/
        readonly _attackType: number; /*��������
0��������е���
1������֡�˺�
2�������˺�
3�������˺�*/
        readonly _attackPerMin: number; /*ÿ���ӹ�������*/
        readonly _dps: number; /*ÿ���˺�*/
        readonly _bullet: number; /*�ڵ�ID*/
        readonly _shoot_number: number; /*ÿ�η�����ӵ���*/
        readonly _distance: number; /*���*/
        readonly _bullet_speed: number; /*�����ٶ�*/
        readonly _scatter: string; /*ɢ��Ƕ�*/
        readonly _vertAngleFix: number; /*����Ƕȴ�ֱ��������*/
        readonly _effectName: string; /*�����Ч��*/
        readonly _aniName: string; /*���Ŷ�����*/
        readonly _dmgAreaType: number; /*�˺���������
0��������ΪԲ�ĵ�Բ����������ն�ࣩ
1��ǰ�����Σ������ࣩ
2��ǰ��׶�Σ������������ࣩ
����뾶����̾���*/
        readonly _rayWidth: number; /*�������������*/
        readonly _heat_quantity: number; /*����������0��ʾû�й������ƣ�*/
        readonly _special_effect: string; /*����Ч��*/
        readonly _sound_effect: string; /*��Ч*/

        constructor(id: number, name: string, sort: number, prefab: string, icon: string, price: number, snipeMode: number, attackType: number, attackPerMin: number, dps: number, bullet: number, shoot_number: number, distance: number, bullet_speed: number, scatter: string, vertAngleFix: number, effectName: string, aniName: string, dmgAreaType: number, rayWidth: number, heat_quantity: number, special_effect: string, sound_effect: string) {
            this._id = id;
            this._name = name;
            this._sort = sort;
            this._prefab = prefab;
            this._icon = icon;
            this._price = price;
            this._snipeMode = snipeMode;
            this._attackType = attackType;
            this._attackPerMin = attackPerMin;
            this._dps = dps;
            this._bullet = bullet;
            this._shoot_number = shoot_number;
            this._distance = distance;
            this._bullet_speed = bullet_speed;
            this._scatter = scatter;
            this._vertAngleFix = vertAngleFix;
            this._effectName = effectName;
            this._aniName = aniName;
            this._dmgAreaType = dmgAreaType;
            this._rayWidth = rayWidth;
            this._heat_quantity = heat_quantity;
            this._special_effect = special_effect;
            this._sound_effect = sound_effect;
        }
    }

    var o_config_PrimaryWeaponData_map : Map<number, o_config_PrimaryWeaponData>;
    function config_PrimaryWeaponData_loaded(json: object): void {
        o_config_PrimaryWeaponData_map = new Map<number, o_config_PrimaryWeaponData>();

        for (let i in json['root']) {
            let id: number = parseInt(json['root'][i]["id"]);
            let name: string = json['root'][i]["name"];
            let sort: number = parseInt(json['root'][i]["sort"]);
            let prefab: string = json['root'][i]["prefab"];
            let icon: string = json['root'][i]["icon"];
            let price: number = parseInt(json['root'][i]["price"]);
            let snipeMode: number = parseInt(json['root'][i]["snipeMode"]);
            let attackType: number = parseInt(json['root'][i]["attackType"]);
            let attackPerMin: number = parseInt(json['root'][i]["attackPerMin"]);
            let dps: number = parseInt(json['root'][i]["dps"]);
            let bullet: number = parseInt(json['root'][i]["bullet"]);
            let shoot_number: number = parseInt(json['root'][i]["shoot_number"]);
            let distance: number = parseInt(json['root'][i]["distance"]);
            let bullet_speed: number = parseInt(json['root'][i]["bullet_speed"]);
            let scatter: string = json['root'][i]["scatter"];
            let vertAngleFix: number = parseFloat(json['root'][i]["vertAngleFix"]);
            let effectName: string = json['root'][i]["effectName"];
            let aniName: string = json['root'][i]["aniName"];
            let dmgAreaType: number = parseInt(json['root'][i]["dmgAreaType"]);
            let rayWidth: number = parseFloat(json['root'][i]["rayWidth"]);
            let heat_quantity: number = parseFloat(json['root'][i]["heat_quantity"]);
            let special_effect: string = json['root'][i]["special_effect"];
            let sound_effect: string = json['root'][i]["sound_effect"];

            o_config_PrimaryWeaponData_map.set(id, new o_config_PrimaryWeaponData(id, name, sort, prefab, icon, price, snipeMode, attackType, attackPerMin, dps, bullet, shoot_number, distance, bullet_speed, scatter, vertAngleFix, effectName, aniName, dmgAreaType, rayWidth, heat_quantity, special_effect, sound_effect));
        }
        expectation--;
    }
    function init_config_PrimaryWeaponData(path: string, fun:fun_config_file_load): void {
        fun(path + "/PrimaryWeaponData.json", config_PrimaryWeaponData_loaded);
    }
    //RandomData.xls
    export class o_config_RandomData {
        readonly _id: number; /*id*/
        readonly _reward_list: oCommonReward; /*����*/
        readonly _weight: number; /*Ȩ��*/

        constructor(id: number, reward_list: oCommonReward, weight: number) {
            this._id = id;
            this._reward_list = reward_list;
            this._weight = weight;
        }
    }

    var o_config_RandomData_map : Map<number, o_config_RandomData>;
    function config_RandomData_loaded(json: object): void {
        o_config_RandomData_map = new Map<number, o_config_RandomData>();

        for (let i in json['root']) {
            let id: number = parseInt(json['root'][i]["id"]);
            let reward_list_value = json['root'][i]["reward_list"].toString().split(',');
            let reward_list: oCommonReward = new oCommonReward(parseInt(reward_list_value[0]), parseInt(reward_list_value[1]), parseInt(reward_list_value[2]),);
            let weight: number = parseInt(json['root'][i]["weight"]);

            o_config_RandomData_map.set(id, new o_config_RandomData(id, reward_list, weight));
        }
        expectation--;
    }
    function init_config_RandomData(path: string, fun:fun_config_file_load): void {
        fun(path + "/RandomData.json", config_RandomData_loaded);
    }
    //RankData.xls
    export class o_config_RankData {
        readonly _id: number; /*ID*/
        readonly _name: string; /*��������*/
        readonly _exp: number; /*����*/
        readonly _getPoint: number; /*��ü��ܵ���*/

        constructor(id: number, name: string, exp: number, getPoint: number) {
            this._id = id;
            this._name = name;
            this._exp = exp;
            this._getPoint = getPoint;
        }
    }

    var o_config_RankData_map : Map<number, o_config_RankData>;
    function config_RankData_loaded(json: object): void {
        o_config_RankData_map = new Map<number, o_config_RankData>();

        for (let i in json['root']) {
            let id: number = parseInt(json['root'][i]["id"]);
            let name: string = json['root'][i]["name"];
            let exp: number = parseInt(json['root'][i]["exp"]);
            let getPoint: number = parseInt(json['root'][i]["getPoint"]);

            o_config_RankData_map.set(id, new o_config_RankData(id, name, exp, getPoint));
        }
        expectation--;
    }
    function init_config_RankData(path: string, fun:fun_config_file_load): void {
        fun(path + "/RankData.json", config_RankData_loaded);
    }
    //RightWeaponData.xls
    export class o_config_RightWeaponData {
        readonly _id: number; /*���*/
        readonly _name: string; /*����*/
        readonly _sort: number; /*����*/
        readonly _prefab: string; /*Ԥ��*/
        readonly _icon: string; /*ͼ��*/
        readonly _price: number; /*�۸�*/
        readonly _dps: number; /*�˺�*/
        readonly _bullet: number; /*�ڵ�ID*/
        readonly _shoot_number: number; /*������*/
        readonly _shoot_inv: number; /*������*/
        readonly _distance: number; /*���*/
        readonly _bullet_speed: number; /*�����ٶ�*/
        readonly _scatter: string; /*ɢ��Ƕ�*/
        readonly _vertAngleFix: number; /*����Ƕȴ�ֱ��������*/
        readonly _skill: number; /*����ID*/
        readonly _special_effect: string; /*����Ч��*/

        constructor(id: number, name: string, sort: number, prefab: string, icon: string, price: number, dps: number, bullet: number, shoot_number: number, shoot_inv: number, distance: number, bullet_speed: number, scatter: string, vertAngleFix: number, skill: number, special_effect: string) {
            this._id = id;
            this._name = name;
            this._sort = sort;
            this._prefab = prefab;
            this._icon = icon;
            this._price = price;
            this._dps = dps;
            this._bullet = bullet;
            this._shoot_number = shoot_number;
            this._shoot_inv = shoot_inv;
            this._distance = distance;
            this._bullet_speed = bullet_speed;
            this._scatter = scatter;
            this._vertAngleFix = vertAngleFix;
            this._skill = skill;
            this._special_effect = special_effect;
        }
    }

    var o_config_RightWeaponData_map : Map<number, o_config_RightWeaponData>;
    function config_RightWeaponData_loaded(json: object): void {
        o_config_RightWeaponData_map = new Map<number, o_config_RightWeaponData>();

        for (let i in json['root']) {
            let id: number = parseInt(json['root'][i]["id"]);
            let name: string = json['root'][i]["name"];
            let sort: number = parseInt(json['root'][i]["sort"]);
            let prefab: string = json['root'][i]["prefab"];
            let icon: string = json['root'][i]["icon"];
            let price: number = parseInt(json['root'][i]["price"]);
            let dps: number = parseInt(json['root'][i]["dps"]);
            let bullet: number = parseInt(json['root'][i]["bullet"]);
            let shoot_number: number = parseInt(json['root'][i]["shoot_number"]);
            let shoot_inv: number = parseFloat(json['root'][i]["shoot_inv"]);
            let distance: number = parseInt(json['root'][i]["distance"]);
            let bullet_speed: number = parseInt(json['root'][i]["bullet_speed"]);
            let scatter: string = json['root'][i]["scatter"];
            let vertAngleFix: number = parseFloat(json['root'][i]["vertAngleFix"]);
            let skill: number = parseInt(json['root'][i]["skill"]);
            let special_effect: string = json['root'][i]["special_effect"];

            o_config_RightWeaponData_map.set(id, new o_config_RightWeaponData(id, name, sort, prefab, icon, price, dps, bullet, shoot_number, shoot_inv, distance, bullet_speed, scatter, vertAngleFix, skill, special_effect));
        }
        expectation--;
    }
    function init_config_RightWeaponData(path: string, fun:fun_config_file_load): void {
        fun(path + "/RightWeaponData.json", config_RightWeaponData_loaded);
    }
    //SignData.xls
    export class o_config_SignData {
        readonly _id: number; /*id*/
        readonly _day: string; /*����*/
        readonly _reward_list: oCommonReward; /*����*/

        constructor(id: number, day: string, reward_list: oCommonReward) {
            this._id = id;
            this._day = day;
            this._reward_list = reward_list;
        }
    }

    var o_config_SignData_map : Map<number, o_config_SignData>;
    function config_SignData_loaded(json: object): void {
        o_config_SignData_map = new Map<number, o_config_SignData>();

        for (let i in json['root']) {
            let id: number = parseInt(json['root'][i]["id"]);
            let day: string = json['root'][i]["day"];
            let reward_list_value = json['root'][i]["reward_list"].toString().split(',');
            let reward_list: oCommonReward = new oCommonReward(parseInt(reward_list_value[0]), parseInt(reward_list_value[1]), parseInt(reward_list_value[2]),);

            o_config_SignData_map.set(id, new o_config_SignData(id, day, reward_list));
        }
        expectation--;
    }
    function init_config_SignData(path: string, fun:fun_config_file_load): void {
        fun(path + "/SignData.json", config_SignData_loaded);
    }
    //SkillData.xls
    export class o_config_SkillData {
        readonly _id: number; /*����ID*/
        readonly _name: string; /*����*/
        readonly _icon: string; /*����ͼ��*/
        readonly _skillType: number; /*��������
0����������
1���ٻ���λ
2��ʩ�Ӽ���Ч��
3��BUFF*/
        readonly _bindId: number; /*��id
��������<������>
�ٻ���λ<SmallMechaData>
ʩ�Ӽ���Ч��<SkillEffectData>
BUFF<BuffData>*/
        readonly _targetType: number; /*����Ч����BUFF���ܵ����ö������͡�
0������
1������+��Χһ����Χ*/
        readonly _value: number; /*������ֵ���˺��������ٷֱȣ�*/
        readonly _range: number; /*Ч����Χ*/
        readonly _time_casting: number; /*���ܳ���ʱ�����룩*/
        readonly _time_cd: number; /*������ȴʱ�䣨�룩*/
        readonly _effect: string; /*Ч��*/
        readonly _sound_effect: string; /*��Ч*/

        constructor(id: number, name: string, icon: string, skillType: number, bindId: number, targetType: number, value: number, range: number, time_casting: number, time_cd: number, effect: string, sound_effect: string) {
            this._id = id;
            this._name = name;
            this._icon = icon;
            this._skillType = skillType;
            this._bindId = bindId;
            this._targetType = targetType;
            this._value = value;
            this._range = range;
            this._time_casting = time_casting;
            this._time_cd = time_cd;
            this._effect = effect;
            this._sound_effect = sound_effect;
        }
    }

    var o_config_SkillData_map : Map<number, o_config_SkillData>;
    function config_SkillData_loaded(json: object): void {
        o_config_SkillData_map = new Map<number, o_config_SkillData>();

        for (let i in json['root']) {
            let id: number = parseInt(json['root'][i]["id"]);
            let name: string = json['root'][i]["name"];
            let icon: string = json['root'][i]["icon"];
            let skillType: number = parseInt(json['root'][i]["skillType"]);
            let bindId: number = parseInt(json['root'][i]["bindId"]);
            let targetType: number = parseInt(json['root'][i]["targetType"]);
            let value: number = parseInt(json['root'][i]["value"]);
            let range: number = parseInt(json['root'][i]["range"]);
            let time_casting: number = parseInt(json['root'][i]["time_casting"]);
            let time_cd: number = parseInt(json['root'][i]["time_cd"]);
            let effect: string = json['root'][i]["effect"];
            let sound_effect: string = json['root'][i]["sound_effect"];

            o_config_SkillData_map.set(id, new o_config_SkillData(id, name, icon, skillType, bindId, targetType, value, range, time_casting, time_cd, effect, sound_effect));
        }
        expectation--;
    }
    function init_config_SkillData(path: string, fun:fun_config_file_load): void {
        fun(path + "/SkillData.json", config_SkillData_loaded);
    }
    //SkillEffectData.xls
    export class o_config_SkillEffectData {
        readonly _id: number; /*ID*/
        readonly _name: string; /*����*/
        readonly _effName: string; /*��Ч����*/
        readonly _jointId: number; /*���ýڵ�
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

        constructor(id: number, name: string, effName: string, jointId: number) {
            this._id = id;
            this._name = name;
            this._effName = effName;
            this._jointId = jointId;
        }
    }

    var o_config_SkillEffectData_map : Map<number, o_config_SkillEffectData>;
    function config_SkillEffectData_loaded(json: object): void {
        o_config_SkillEffectData_map = new Map<number, o_config_SkillEffectData>();

        for (let i in json['root']) {
            let id: number = parseInt(json['root'][i]["id"]);
            let name: string = json['root'][i]["name"];
            let effName: string = json['root'][i]["effName"];
            let jointId: number = parseInt(json['root'][i]["jointId"]);

            o_config_SkillEffectData_map.set(id, new o_config_SkillEffectData(id, name, effName, jointId));
        }
        expectation--;
    }
    function init_config_SkillEffectData(path: string, fun:fun_config_file_load): void {
        fun(path + "/SkillEffectData.json", config_SkillEffectData_loaded);
    }
    //SmallMechaData.xls
    export class o_config_SmallMechaData {
        readonly _id: number; /*����ID*/
        readonly _icon: number; /*����ͼ��*/
        readonly _name: string; /*����*/
        readonly _describe: string; /*����*/
        readonly _prefab: string; /*Ԥ��*/
        readonly _type: number; /*����
0������*/
        readonly _mainWpn: number; /*������id*/
        readonly _exp: number; /*����*/
        readonly _life: number; /*����*/
        readonly _speed: number; /*�ٶ�*/
        readonly _bodyRange: number; /*�����Χ*/
        readonly _height: number; /*�߶�*/

        constructor(id: number, icon: number, name: string, describe: string, prefab: string, type: number, mainWpn: number, exp: number, life: number, speed: number, bodyRange: number, height: number) {
            this._id = id;
            this._icon = icon;
            this._name = name;
            this._describe = describe;
            this._prefab = prefab;
            this._type = type;
            this._mainWpn = mainWpn;
            this._exp = exp;
            this._life = life;
            this._speed = speed;
            this._bodyRange = bodyRange;
            this._height = height;
        }
    }

    var o_config_SmallMechaData_map : Map<number, o_config_SmallMechaData>;
    function config_SmallMechaData_loaded(json: object): void {
        o_config_SmallMechaData_map = new Map<number, o_config_SmallMechaData>();

        for (let i in json['root']) {
            let id: number = parseInt(json['root'][i]["id"]);
            let icon: number = parseInt(json['root'][i]["icon"]);
            let name: string = json['root'][i]["name"];
            let describe: string = json['root'][i]["describe"];
            let prefab: string = json['root'][i]["prefab"];
            let type: number = parseInt(json['root'][i]["type"]);
            let mainWpn: number = parseInt(json['root'][i]["mainWpn"]);
            let exp: number = parseInt(json['root'][i]["exp"]);
            let life: number = parseInt(json['root'][i]["life"]);
            let speed: number = parseInt(json['root'][i]["speed"]);
            let bodyRange: number = parseFloat(json['root'][i]["bodyRange"]);
            let height: number = parseFloat(json['root'][i]["height"]);

            o_config_SmallMechaData_map.set(id, new o_config_SmallMechaData(id, icon, name, describe, prefab, type, mainWpn, exp, life, speed, bodyRange, height));
        }
        expectation--;
    }
    function init_config_SmallMechaData(path: string, fun:fun_config_file_load): void {
        fun(path + "/SmallMechaData.json", config_SmallMechaData_loaded);
    }
    //SpecialWeaponData.xls
    export class o_config_SpecialWeaponData {
        readonly _id: number; /*ID*/
        readonly _name: string; /*����*/
        readonly _price: number; /*�۸�*/
        readonly _dps: number; /*�˺�*/
        readonly _range: number; /*�˺��뾶*/
        readonly _distance: number; /*���*/
        readonly _skill: number; /*����ID*/

        constructor(id: number, name: string, price: number, dps: number, range: number, distance: number, skill: number) {
            this._id = id;
            this._name = name;
            this._price = price;
            this._dps = dps;
            this._range = range;
            this._distance = distance;
            this._skill = skill;
        }
    }

    var o_config_SpecialWeaponData_map : Map<number, o_config_SpecialWeaponData>;
    function config_SpecialWeaponData_loaded(json: object): void {
        o_config_SpecialWeaponData_map = new Map<number, o_config_SpecialWeaponData>();

        for (let i in json['root']) {
            let id: number = parseInt(json['root'][i]["id"]);
            let name: string = json['root'][i]["name"];
            let price: number = parseInt(json['root'][i]["price"]);
            let dps: number = parseInt(json['root'][i]["dps"]);
            let range: number = parseInt(json['root'][i]["range"]);
            let distance: number = parseInt(json['root'][i]["distance"]);
            let skill: number = parseInt(json['root'][i]["skill"]);

            o_config_SpecialWeaponData_map.set(id, new o_config_SpecialWeaponData(id, name, price, dps, range, distance, skill));
        }
        expectation--;
    }
    function init_config_SpecialWeaponData(path: string, fun:fun_config_file_load): void {
        fun(path + "/SpecialWeaponData.json", config_SpecialWeaponData_loaded);
    }
    //TalentData.xls
    export class o_config_TalentData {
        readonly _id: number; /*�츳ID*/
        readonly _icon: number; /*�츳ͼ��*/
        readonly _point: number; /*�������輼�ܵ���*/
        readonly _effect: string; /*Ч��*/

        constructor(id: number, icon: number, point: number, effect: string) {
            this._id = id;
            this._icon = icon;
            this._point = point;
            this._effect = effect;
        }
    }

    var o_config_TalentData_map : Map<number, o_config_TalentData>;
    function config_TalentData_loaded(json: object): void {
        o_config_TalentData_map = new Map<number, o_config_TalentData>();

        for (let i in json['root']) {
            let id: number = parseInt(json['root'][i]["id"]);
            let icon: number = parseInt(json['root'][i]["icon"]);
            let point: number = parseInt(json['root'][i]["point"]);
            let effect: string = json['root'][i]["effect"];

            o_config_TalentData_map.set(id, new o_config_TalentData(id, icon, point, effect));
        }
        expectation--;
    }
    function init_config_TalentData(path: string, fun:fun_config_file_load): void {
        fun(path + "/TalentData.json", config_TalentData_loaded);
    }
    //TaskData.xls
    export class o_config_TaskData {
        readonly _id: number; /*id*/
        readonly _type: TaskType; /*��������*/
        readonly _param_list: number; /*�������*/
        readonly _reward_list: oCommonReward; /*������*/
        readonly _description: string; /*��������*/

        constructor(id: number, type: TaskType, param_list: number, reward_list: oCommonReward, description: string) {
            this._id = id;
            this._type = type;
            this._param_list = param_list;
            this._reward_list = reward_list;
            this._description = description;
        }
    }

    var o_config_TaskData_map : Map<number, o_config_TaskData>;
    function config_TaskData_loaded(json: object): void {
        o_config_TaskData_map = new Map<number, o_config_TaskData>();

        for (let i in json['root']) {
            let id: number = parseInt(json['root'][i]["id"]);
            let type: number = parseInt(json['root'][i]["type"]);
            let param_list: number = parseInt(json['root'][i]["param_list"]);
            let reward_list_value = json['root'][i]["reward_list"].toString().split(',');
            let reward_list: oCommonReward = new oCommonReward(parseInt(reward_list_value[0]), parseInt(reward_list_value[1]), parseInt(reward_list_value[2]),);
            let description: string = json['root'][i]["description"];

            o_config_TaskData_map.set(id, new o_config_TaskData(id, type, param_list, reward_list, description));
        }
        expectation--;
    }
    function init_config_TaskData(path: string, fun:fun_config_file_load): void {
        fun(path + "/TaskData.json", config_TaskData_loaded);
    }
    //TaskLimitData.xls
    export class o_config_TaskLimitData {
        readonly _id: number; /*id*/
        readonly _type: TaskType; /*��������*/
        readonly _param_list: Array<number>;/*�������*/
        readonly _description: string; /*��������*/
        readonly _exp: number; /*������*/

        constructor(id: number, type: TaskType, param_list: Array<number>, description: string, exp: number) {
            this._id = id;
            this._type = type;
            this._param_list = param_list;
            this._description = description;
            this._exp = exp;
        }
    }

    var o_config_TaskLimitData_map : Map<number, o_config_TaskLimitData>;
    function config_TaskLimitData_loaded(json: object): void {
        o_config_TaskLimitData_map = new Map<number, o_config_TaskLimitData>();

        for (let i in json['root']) {
            let id: number = parseInt(json['root'][i]["id"]);
            let type: number = parseInt(json['root'][i]["type"]);

            let param_list = new Array<number>();
            let  param_list_ary = json['root'][i]["param_list"].toString().split(';');
            for (let i = 0; i < param_list_ary.length; i++) {
                let oo : number = parseInt(param_list_ary[i]);
                param_list.push(oo);
            }
            let description: string = json['root'][i]["description"];
            let exp: number = parseInt(json['root'][i]["exp"]);

            o_config_TaskLimitData_map.set(id, new o_config_TaskLimitData(id, type, param_list, description, exp));
        }
        expectation--;
    }
    function init_config_TaskLimitData(path: string, fun:fun_config_file_load): void {
        fun(path + "/TaskLimitData.json", config_TaskLimitData_loaded);
    }
    //TurretData.xls
    export class o_config_TurretData {
        readonly _id: number; /*ID*/
        readonly _name: string; /*����*/
        readonly _sort: number; /*����*/
        readonly _prefab: string; /*Ԥ��*/
        readonly _icon: string; /*ͼ��*/
        readonly _price: number; /*�۸�*/
        readonly _skill: number; /*����ID*/
        readonly _effect: string; /*Ч��*/

        constructor(id: number, name: string, sort: number, prefab: string, icon: string, price: number, skill: number, effect: string) {
            this._id = id;
            this._name = name;
            this._sort = sort;
            this._prefab = prefab;
            this._icon = icon;
            this._price = price;
            this._skill = skill;
            this._effect = effect;
        }
    }

    var o_config_TurretData_map : Map<number, o_config_TurretData>;
    function config_TurretData_loaded(json: object): void {
        o_config_TurretData_map = new Map<number, o_config_TurretData>();

        for (let i in json['root']) {
            let id: number = parseInt(json['root'][i]["id"]);
            let name: string = json['root'][i]["name"];
            let sort: number = parseInt(json['root'][i]["sort"]);
            let prefab: string = json['root'][i]["prefab"];
            let icon: string = json['root'][i]["icon"];
            let price: number = parseInt(json['root'][i]["price"]);
            let skill: number = parseInt(json['root'][i]["skill"]);
            let effect: string = json['root'][i]["effect"];

            o_config_TurretData_map.set(id, new o_config_TurretData(id, name, sort, prefab, icon, price, skill, effect));
        }
        expectation--;
    }
    function init_config_TurretData(path: string, fun:fun_config_file_load): void {
        fun(path + "/TurretData.json", config_TurretData_loaded);
    }

    export function initilize(path : string, fun: fun_config_file_load) {
        init_config_ArmorData(path, fun);
        init_config_BuffData(path, fun);
        init_config_BulletData(path, fun);
        init_config_CoinData(path, fun);
        init_config_EngineData(path, fun);
        init_config_EquipmentData(path, fun);
        init_config_FreeCoinData(path, fun);
        init_config_LevelData(path, fun);
        init_config_LotteryData(path, fun);
        init_config_MaskData(path, fun);
        init_config_MechaData(path, fun);
        init_config_MechColorData(path, fun);
        init_config_MeleeWeaponData(path, fun);
        init_config_OpenChestData(path, fun);
        init_config_PrimaryWeaponData(path, fun);
        init_config_RandomData(path, fun);
        init_config_RankData(path, fun);
        init_config_RightWeaponData(path, fun);
        init_config_SignData(path, fun);
        init_config_SkillData(path, fun);
        init_config_SkillEffectData(path, fun);
        init_config_SmallMechaData(path, fun);
        init_config_SpecialWeaponData(path, fun);
        init_config_TalentData(path, fun);
        init_config_TaskData(path, fun);
        init_config_TaskLimitData(path, fun);
        init_config_TurretData(path, fun);
    }

    export function get_config_ArmorData() {
        return o_config_ArmorData_map;
    }

    export function get_config_BuffData() {
        return o_config_BuffData_map;
    }

    export function get_config_BulletData() {
        return o_config_BulletData_map;
    }

    export function get_config_CoinData() {
        return o_config_CoinData_map;
    }

    export function get_config_EngineData() {
        return o_config_EngineData_map;
    }

    export function get_config_EquipmentData() {
        return o_config_EquipmentData_map;
    }

    export function get_config_FreeCoinData() {
        return o_config_FreeCoinData_map;
    }

    export function get_config_LevelData() {
        return o_config_LevelData_map;
    }

    export function get_config_LotteryData() {
        return o_config_LotteryData_map;
    }

    export function get_config_MaskData() {
        return o_config_MaskData_map;
    }

    export function get_config_MechaData() {
        return o_config_MechaData_map;
    }

    export function get_config_MechColorData() {
        return o_config_MechColorData_map;
    }

    export function get_config_MeleeWeaponData() {
        return o_config_MeleeWeaponData_map;
    }

    export function get_config_OpenChestData() {
        return o_config_OpenChestData_map;
    }

    export function get_config_PrimaryWeaponData() {
        return o_config_PrimaryWeaponData_map;
    }

    export function get_config_RandomData() {
        return o_config_RandomData_map;
    }

    export function get_config_RankData() {
        return o_config_RankData_map;
    }

    export function get_config_RightWeaponData() {
        return o_config_RightWeaponData_map;
    }

    export function get_config_SignData() {
        return o_config_SignData_map;
    }

    export function get_config_SkillData() {
        return o_config_SkillData_map;
    }

    export function get_config_SkillEffectData() {
        return o_config_SkillEffectData_map;
    }

    export function get_config_SmallMechaData() {
        return o_config_SmallMechaData_map;
    }

    export function get_config_SpecialWeaponData() {
        return o_config_SpecialWeaponData_map;
    }

    export function get_config_TalentData() {
        return o_config_TalentData_map;
    }

    export function get_config_TaskData() {
        return o_config_TaskData_map;
    }

    export function get_config_TaskLimitData() {
        return o_config_TaskLimitData_map;
    }

    export function get_config_TurretData() {
        return o_config_TurretData_map;
    }
    export function config_load_completed() : boolean { return expectation == 0;}
}
