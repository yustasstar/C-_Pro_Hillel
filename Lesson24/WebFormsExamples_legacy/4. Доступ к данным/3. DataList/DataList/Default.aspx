<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="DataList._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
     <form id="Form1" method="post" runat="server">
			<asp:DataList id="DataList1" runat="server">
			    
			   <%-- шаблон "шапки" --%> 
				<HeaderTemplate>Header<hr /></HeaderTemplate>
				
				<%-- шаблон завершителя --%>
					<FooterTemplate>Footer<hr /></FooterTemplate>
				
				<%-- шаблон элемента --%>
				<ItemTemplate>
				    <%-- добавление данных в шаблон --%>
                    <%-- DataBinder.Eval обрабатывает выражение привязки данных во время исполнения программы. --%>
                    <%-- Container.DataItem получает или задает элемент данных, связанный с объектом DataListItem в элементе управления DataList. --%>
					<%# DataBinder.Eval (Container.DataItem, "name")%>, 
					<%# DataBinder.Eval (Container.DataItem, "author")%>,
					<%# DataBinder.Eval (Container.DataItem, "press")%>
				</ItemTemplate>
				
				<%-- альтернативный шаблон элемента (если указан, то будет чередование шаблонов ItemTemplate и AlternatingItemTemplate) --%>
				<AlternatingItemTemplate>
				    <%-- добавление данных в шаблон --%>
					<%# DataBinder.Eval (Container.DataItem, "name")%>, 
					<%# DataBinder.Eval (Container.DataItem, "author")%>,
					<%# DataBinder.Eval (Container.DataItem, "press")%>
				</AlternatingItemTemplate>
				
				<%-- стиль шаблона альтернативного элемента --%>
				<AlternatingItemStyle BackColor="pink" ForeColor="blue">
                </AlternatingItemStyle>
                
                <%-- шаблон выбранного элемента --%>
				<SelectedItemTemplate>
				    <%-- добавление данных в шаблон --%>
					<%# DataBinder.Eval (Container.DataItem, "name")%>, 
					<%# DataBinder.Eval (Container.DataItem, "author")%>,
					<%# DataBinder.Eval (Container.DataItem, "press")%>
				</SelectedItemTemplate>
				
				<%-- стиль шаблона выбранного элемента --%>
				<SelectedItemStyle BackColor="#333333" ForeColor="white" Font-Bold="true">
                 </SelectedItemStyle>
                 
                 <%-- шаблон разделителя --%>
				<SeparatorTemplate>
					<div style="overflow: hidden; height:5px; border-top:1px dashed red;" />
				</SeparatorTemplate>
			</asp:DataList>
		</form>
</body>
</html>
