﻿INSERT INTO t_subject_type
VALUES
	(999, '未知'),
	(1, '一、资产类'),
	(2, '二、负债类'),
	(
		3,
		'三、所有者权益类'
	),
	(4, '四、成本类'),
	(5, '五、损益类');
INSERT INTO t_subject (
	subject_id,
	subject_type,
	subject_name,
	direction
)
VALUES
	('1001', 1, '库存现金', 0),
	('1002', 1, '银行存款', 0),
	(
		'1012',
		1,
		'其他货币资金',
		0
	),
	('1101', 1, '短期投资', 0),
	('1121', 1, '应收票据', 0),
	('1122', 1, '应收账款', 0),
	('1123', 1, '预付账款', 0),
	('1131', 1, '应收股利', 0),
	('1132', 1, '应收利息', 0),
	(
		'1221',
		1,
		'其他应收款',
		0
	),
	('1401', 1, '材料采购', 0),
	('1402', 1, '在途物资', 0),
	('1403', 1, '原材料', 0),
	(
		'1404',
		1,
		'材料成本差异',
		0
	),
	('1405', 1, '库存商品', 0),
	(
		'1407',
		1,
		'商品进销差价',
		0
	),
	(
		'1408',
		1,
		'委托加工物资',
		0
	),
	('1411', 1, '周转材料', 0),
	(
		'1421',
		1,
		'消耗性生物资产',
		0
	),
	(
		'1501',
		1,
		'长期债券投资',
		0
	),
	(
		'1511',
		1,
		'长期股权投资',
		0
	),
	('1601', 1, '固定资产', 0),
	('1602', 1, '累计折旧', 1),
	('1604', 1, '在建工程', 0),
	('1605', 1, '工程物资', 0),
	(
		'1606',
		1,
		'固定资产清理',
		0
	),
	(
		'1621',
		1,
		'生产性生物资产',
		0
	),
	(
		'1622',
		1,
		'生产性生物资产累计折旧',
		1
	),
	('1701', 1, '无形资产', 0),
	('1702', 1, '累计摊销', 1),
	(
		'1801',
		1,
		'长期待摊费用',
		0
	),
	(
		'1901',
		1,
		'待处理财产损溢',
		0
	),
	('2001', 2, '短期借款', 1),
	('2201', 2, '应付票据', 1),
	('2202', 2, '应付账款', 1),
	('2203', 2, '预收账款', 1),
	(
		'2211',
		2,
		'应付职工薪酬',
		1
	),
	('2221', 2, '应交税费', 1),
	('2231', 2, '应付利息', 1),
	('2232', 2, '应付利润', 1),
	(
		'2241',
		2,
		'其他应付款',
		1
	),
	('2401', 2, '递延收益', 1),
	('2501', 2, '长期借款', 1),
	(
		'2701',
		2,
		'长期应付款',
		1
	),
	('3001', 3, '实收资本', 1),
	('3002', 3, '资本公积', 1),
	('3101', 3, '盈余公积', 1),
	('3103', 3, '本年利润', 1),
	('3104', 3, '利润分配', 1),
	('4001', 4, '生产成本', 0),
	('4101', 4, '制造费用', 0),
	('4301', 4, '研发支出', 0),
	('4401', 4, '工程施工', 0),
	('4403', 4, '机械作业', 0),
	(
		'5001',
		5,
		'主营业务收入',
		2
	),
	(
		'5051',
		5,
		'其他业务收入',
		2
	),
	('5111', 5, '投资收益', 2),
	(
		'5301',
		5,
		'营业外收入',
		2
	),
	(
		'5401',
		5,
		'主营业务成本',
		2
	),
	(
		'5402',
		5,
		'其他业务成本',
		2
	),
	(
		'5403',
		5,
		'营业税金及附加',
		2
	),
	('5601', 5, '销售费用', 2),
	('5602', 5, '管理费用', 2),
	('5603', 5, '财务费用', 2),
	(
		'5711',
		5,
		'营业外支出',
		2
	),
	(
		'5801',
		5,
		'所得税费用',
		2
	);