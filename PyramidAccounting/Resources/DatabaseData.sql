﻿INSERT INTO t_subject_type
VALUES
	(999, '未知'),
	(1, '一、资产类'),
	(2, '二、负债类'),
	(
		3,
		'三、净资产类'
	),
	(4, '四、收入类'),
	(5, '五、支出类');
INSERT INTO t_subject (
	sid,
	subject_id,
	subject_type,
	subject_name
)
VALUES
	(
		'1',
		'1001',
		1,
		'库存现金'
	),
	(
		'2',
		'1002',
		1,
		' 银行存款'
	),
	(
		'3',
		'1011',
		1,
		'零余额账户用款额度'
	),
	(
		'4',
		'1101',
		1,
		'短期投资'
	),
	(
		'5',
		'1201',
		1,
		'财政应返还额度'
	),
	(
		'',
		'120101',
		1,
		'财政直接支付'
	),
	(
		'',
		'120102',
		1,
		'财政授权支付'
	),
	(
		'6',
		'1211',
		1,
		'应收票据'
	),
	(
		'7',
		'1212',
		1,
		'应收账款'
	),
	(
		'8',
		'1213',
		1,
		'预付账款'
	),
	(
		'9',
		'1215',
		1,
		'其他应收款'
	),
	(
		'10',
		'1301',
		1,
		'存 货'
	),
	(
		'11',
		'1401',
		1,
		'长期投资'
	),
	(
		'12',
		'1501',
		1,
		'固定资产'
	),
	(
		'13',
		'1502',
		1,
		'累计折旧'
	),
	(
		'14',
		'1511',
		1,
		'在建工程'
	),
	(
		'15',
		'1601',
		1,
		'无形资产'
	),
	(
		'16',
		'1602',
		1,
		'累计摊销'
	),
	(
		'17',
		'1701',
		1,
		'待处置资产损溢'
	),
	(
		'18',
		'2001',
		2,
		'短期借款'
	),
	(
		'19',
		'2101',
		2,
		'应缴税费'
	),
	(
		'20',
		'2102',
		2,
		'应缴国库款'
	),
	(
		'21',
		'2103',
		2,
		'应缴财政专户款'
	),
	(
		'22',
		'2201',
		2,
		'应付职工薪酬'
	),
	(
		'23',
		'2301',
		2,
		'付票据'
	),
	(
		'24',
		'2302',
		2,
		'应付账款'
	),
	(
		'25',
		'2303',
		2,
		'预收账款 '
	),
	(
		'26',
		'2305',
		2,
		'其他应付款'
	),
	(
		'27',
		'2401',
		2,
		'长期借款'
	),
	(
		'28',
		'2402',
		2,
		'长期应付款'
	),
	(
		'29',
		'3001',
		3,
		'事业基金'
	),
	(
		'30',
		'3101',
		3,
		'非流动资产基金'
	),
	(
		'',
		'310101',
		3,
		' 长期投资'
	),
	(
		'',
		'310102',
		3,
		'固定资产'
	),
	(
		'',
		'310103',
		3,
		'在建工程'
	),
	(
		'',
		'310104',
		3,
		'无形资产'
	),
	(
		'31',
		'3201',
		3,
		'专用基金'
	),
	(
		'32',
		'3301',
		3,
		'财政补助结转'
	),
	(
		'',
		'330101',
		3,
		'基本支出结转'
	),
	(
		'',
		'330102',
		3,
		'项目支出结转'
	),
	(
		'33',
		'3302',
		3,
		'财政补助结余'
	),
	(
		'34',
		'3401',
		3,
		'非财政补助结余'
	),
	(
		'35',
		'3402',
		3,
		'事业结余'
	),
	(
		'36',
		'3403',
		3,
		' 经营结余'
	),
	(
		'37',
		'3404',
		3,
		'非财政补助结余分配'
	),
	(
		'38',
		'4001',
		4,
		'财政补助收入'
	),
	(
		'39',
		'4101',
		4,
		'事业收入'
	),
	(
		'40',
		'4201',
		4,
		'上级补助收入'
	),
	(
		'41',
		'4301',
		4,
		'附属单位上缴收入'
	),
	(
		'42',
		'4401',
		4,
		'经营收入'
	),
	(
		'43',
		'4501',
		4,
		'其他收入'
	),
	(
		'44',
		'5001',
		5,
		'事业支出'
	),
	(
		'45',
		'5101',
		5,
		'上缴上级支出'
	),
	(
		'46',
		'5201',
		5,
		'对附属单位补助支出'
	),
	(
		'47',
		'5301',
		5,
		'经营支出'
	),
	(
		'48',
		'5401',
		5,
		'其他支出'
	);