CREATE TABLE T_BOOKS (									--账套表
    ID                TEXT PRIMARY KEY,					--账套ID
    BOOK_NAME         TEXT,								--账套名称
	COMPANY_NAME	  TEXT,								--单位名称
	MONEY_TYPE		  TEXT,								--本位币
    CREATE_DATE       DATE,								--账套启用日期
    ACCOUNTING_SYSTEM TEXT,								--会计制度
	DELETE_MARK		  INTEGER DEFAULT ( 0 )				--删除标志    -1表示已删除
);
CREATE TABLE T_YEAR_FEE (								--科目年初金额设置表
	SUBJECT_ID   TEXT PRIMARY KEY,						--科目编号
	FEE			 DECIMAL,								--年初金额
	BOOKID		 TEXT									--账套ID	
);
CREATE TABLE T_SUBJECT_TYPE (							--科目类型维表
    TYPE_ID   INTEGER,									--科目类别
    TYPE_NAME TEXT										--类别名称
);
CREATE TABLE T_USER (									--用户表
	USERID INTEGER PRIMARY KEY,							--USERID
	USERNAME TEXT NOT NULL UNIQUE,						--用户名
	REALNAME TEXT,										--用户姓名
	PASSWORD TEXT DEFAULT (123456),						--密码
	PHONE_NO TEXT,										--手机号码
	AUTHORITY INTEGER DEFAULT (0),						--权限     0：表示记账  1：审核   2：会计主管 3：管理员 4：超级管理员
	CREATE_TIME DATETIME,								--创建时间
	COMMENTS TEXT,										--用户说明	
	DELETE_MARK INTEGER DEFAULT (0)						--停用标志  0：正是用 1：已停用	
);