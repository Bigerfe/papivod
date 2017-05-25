
//参数依次为（后两个如果指定为空值，则不会发生相应的事件）：
//GridView ID, 正常行背景色,交替行背景色,鼠标指向行背景色,鼠标点击后背景色
function GridViewColor(GridViewId, NormalColor, AlterColor, HoverColor, SelectColor) {

   
    //获取所有要控制的行 
    var AllRows = document.getElementById(GridViewId).getElementsByTagName("tr");

    //设置每一行的背景色和事件，循环从1开始而非0，可以避开表头那一行
    for (var i = 1; i < AllRows.length; i++) {
        //设定本行默认的背景色
        AllRows[i].style.background = i % 2 == 0 ? NormalColor: AlterColor;

        //如果指定了鼠标指向的背景色，则添加onmouseover/onmouseout事件
        //处于选中状态的行发生这两个事件时不改变颜色
        if (HoverColor != "") {
            AllRows[i].onmouseover = function() {
                if (!this.selected) this.style.background = HoverColor;
            }
            if (i % 2 == 0) {
                AllRows[i].onmouseout = function() {
                    if (!this.selected) this.style.background = NormalColor;
                }
            }

            else {
                AllRows[i].onmouseout = function() {
                    if (!this.selected) this.style.background = AlterColor;
                }
            }

            AllRows[i].onmouseout

        }

        //如果指定了鼠标点击的背景色，则添加onclick事件
        //在事件响应中修改被点击行的选中状态
        if (SelectColor != "") {
            AllRows[i].onclick = function() {
                this.style.background = this.style.background == SelectColor ? HoverColor: SelectColor;
                this.selected = !this.selected;
            }
        }

        AllRows[i].style.cursor='pointer';
//        AllRows[i].onclick = function(){
//            
//            var id = this.cells[0].firstChild.value; 
//            
//            this.cells[0].firstChild.checked=(!this.cells[0].firstChild.checked);            
//        
//        }
    }
}


//批量设置优惠信息的排序数字
 function setOffersInfoOrder()
{ 
    if(confirm("您确定当前页面的全部数据设置排序吗?"))
    {
                
                var mm = document.getElementsByName('che');              
                
                var l = mm.length;
                
                var k = 0;
                
                for ( var i=0; i< l; i++)
                {         
                   
                        var offerid = mm[i].value;
                        var newpicorder =$.trim($('#txt'+offerid+"_newofferpic").val());
                        var newnopicorder =$.trim( $('#txt'+offerid+"_newoffernopic").val());
                        
                        var jxpicorder=$.trim($('#txt'+offerid+"_jxofferpic").val());
                        var jxnopicorder = $.trim($('#txt'+offerid+"_jxoffernopic").val());
                        
                        var otherpicorder=$.trim($('#txt'+offerid+"_otherofferpic").val());
                        var othernopicorder = $.trim($('#txt'+offerid+"_otheroffernopic").val());    
                        
                        
                        
                        
                        //执行修改操作
                       setOffersInfoOrder_post(offerid,newpicorder,newnopicorder,jxpicorder,jxnopicorder,otherpicorder,othernopicorder);                        
                        
                        
                }  
                
                alert("设置成功");
                
              
        }   
        
    
}

function setOffersInfoOrder_post(offerid,newpicorder,newnopicorder,jxpicorder,jxnopicorder,otherpicorder,othernopicorder){
	 
	$.post('/sendrequest.aspx', {action:"setOffersInfoOrder_post",offerid:offerid, newpicorder:newpicorder, newnopicorder:newnopicorder, jxpicorder:jxpicorder,jxnopicorder:jxnopicorder,otherpicorder:otherpicorder,othernopicorder:othernopicorder}, function(data){
		 //alert(data);
	});
	 
}

 

 