//权限选择
function select_all(obj){
    var menu2 = document.getElementsByName("m2_"+obj);
    var menu1 = document.getElementById("m1_"+obj);
    for(var i=0;i<menu2.length;i++){
  	    if (menu1.checked){
 	  	    menu2[i].checked = true;
  	    }else{
  	        menu2[i].checked = false;
  	    }
	}
}
//权限操作
function update_qx(obj){
	    var array =new Array();
	    var tt = false;
	    var m1 = document.getElementsByName("m");
	    var num = 0;
	    for(var i=0;i<m1.length;i++){
	        var m1id = m1[i].value;
	        var m2 = document.getElementsByName("m2_"+m1id);
	        for(var j=0;j<m2.length;j++){
	            if(m2[j].checked){
	                array[num] = m2[j].value;
	                num++;
	                tt = true;
	            }
	        }
	    }
	    if (tt){
	        document.getElementById("HD1").value=array;
	    }else{
	        alert("%E4%B8%AD");
	        alert("\u672a\u9009\u62e9\u529f\u80fd\u9009\u9879\uff0c\u8bf7\u91cd\u65b0\u64cd\u4f5c\uff01");
	    }
	}
