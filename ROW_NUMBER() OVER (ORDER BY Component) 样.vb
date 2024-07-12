ROW_NUMBER() OVER (ORDER BY Component)  样 select ROW_NUMBER() OVER (ORDER BY Component),*

Dim Max As String = txtMax.Text + "_Max"
        Dim Min As String = txtMin.Text + "_Min"
        Dim insert As String = "IF EXISTS (  
                            SELECT 1  
                            FROM INFORMATION_SCHEMA.COLUMNS  
                            WHERE TABLE_NAME = 'TestVB' 
                                  AND COLUMN_NAME = '" + Max + "'  
                        )  
                        BEGIN  
                            ALTER TABLE TestVB  
	                        ALTER COLUMN " + Max + " varchar(50) NULL;  
                            ALTER TABLE TestVB  
	                        ALTER COLUMN " + Min + " varchar(50) NULL;  
                        END  
                        ELSE  
                        BEGIN  
                            ALTER TABLE TestVB  
	                        ADD " + Max + " varchar(50) null;
                            ALTER TABLE TestVB  
	                        ADD " + Min + " varchar(50) null;
                        END"

        ' 创建一个新的SqlConnection对象
        Using connection As New SqlConnection(connectionString)
            Try
                ' 打开连接
                connection.Open()

                ' 创建一个SqlCommand对象
                Dim insertCommand As New SqlCommand(insert, connection)
                ' 执行命令  
                insertCommand.ExecuteNonQuery()

            Catch ex As Exception
                ' 异常处理