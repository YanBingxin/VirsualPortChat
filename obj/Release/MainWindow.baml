   M S B A M L   `   `   `  ���� H  DVirsualDevice, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:VirsualDeviceVirsualDevice  a ]PresentationFramework.Aero, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35gJclr-namespace:Microsoft.Windows.Themes;assembly=PresentationFramework.AeroMicrosoft.Windows.Themes O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089;+clr-namespace:System.Text;assembly=mscorlibSystem.Text M ISystem, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089A-clr-namespace:System.IO.Ports;assembly=SystemSystem.IO.Ports     VirsualDevice.MainWindow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     -localclr-namespace:VirsualDevice     ]ThemesJclr-namespace:Microsoft.Windows.Themes;assembly=PresentationFramework.Aero     @encoding+clr-namespace:System.Text;assembly=mscorlib     @parity-clr-namespace:System.IO.Ports;assembly=System       � WindowStartupLocation$  CenterScreen=� � WindowState$ Normal=� � Title$ 串口通讯模拟器��$	��600��$	��800�� J� SnapsToDevicePixels .  � UseLayoutRounding .  � 	Resources  �� MergedDictionaries �� Source   
bconverter  TextBoxBaseControlTemplate �� 
TargetType	 ��Name
 �� CornerRadius ��Name  LogTemplate   VirsualDevice.LogControl � RowDefinitions   Time   Message  TextBoxControlTemplate �� Triggers P� Property P� Value �� 
TargetName �� Value �� Property��  �� $F @pack://application:,,,/VirsualDevice;Component/VirsualStyle.xaml?�%�  &	        &	      &	 j     &	      �� �� " ��.R��� $	 Bd��$
 5��#��z��#��z��#��z�� . ._��� $ PART_ContentHost��# z �� "  .R��� $	 Chrome��$
 3��#��z��#��z�� . ._��  �� �� .+��� $��0��$��9(�$��Bottom=�#��z $��Center=��� $��1��$	��Top=�#��z $��Center=��� " ��.R��� $	 Bd��$
 3��
���iii�$��1q�#��z�� . ._��� $ PART_ContentHost��# z  P�  � {� .  . ��� $ Bd��# � �� � ���� # � �� � ��.���  � ColumnDefinitions �� $
��326* ��� $	��55* ��� $
��415* � �� $��1.47* ��� $��* �.+��� $��操作记录��$��0��
���iii�$��5q�$��1q�$��2��.���� -    ��Name$ rchtxt��#���  " �� VerticalScrollBarVisibility$
 Auto=�. �/� -    /�Name$ flLog�� /� 
Background
 ������� $��0��
���iii�$��自动应答��$��5q�$��1q�$��2��.���  �� $��* ��� $
��auto �.+�&   System.Windows.Controls.DataGrid  $��0,0,0,1q�   AutoGenerateColumns .     HeadersVisibility$ Column=�   CanUserAddRows .     CanUserDeleteRows .  $��0������ *Data.Responses+ �� Mode$ TwoWay=�   EleStyle �� 
TargetType  EleingStyle��%�   &	       &	 B     �� " ��.���  � ��$ Bottom=���  � ��$ Stretch=��� " ��.���  � ��$ Bottom=���  � ��$ Stretch=�    Columns  0  *System.Windows.Controls.DataGridTextColumn  -   
clnAsk��,  &System.Windows.Controls.DataGridColumn!   Header$! 问句��"   Width5  /System.Windows.Controls.DataGridLengthConverter$" * 1  +System.Windows.Controls.DataGridBoundColumn#   ElementStyle## [ $   EditingElementStyle#$ [ %   Binding% �� *Ask+  -   	clnAnswer��$! 回复��$" * ## [ #$ [ % �� *Answer+4  .System.Windows.Controls.DataGridTemplateColumn  $! 删除��$
" auto -   
clnDel��&   CellTemplate& �� .R��� -   $��X��
���  ��$��18��$��9(�� $��1�� �� $
��auto ��� $
��auto ��� $
��auto �.+��� -   ' ��Name$' txtAsk��$��0��#���  ���� *ActualWidth+( �� ElementName$( clnAsk���� -   $' 	txtAnswer��$��1��#���  ���� *ActualWidth+$( 	clnAnswer���� -	   ) ��Name$) btnAddAutoRes��$��+��$��2��
��� � ����� *ActualWidth+$( clnDel���� $��端口参数��$��1��$��0��
���iii�$��5q�$��1q�.��A� -
   * A�Name$	* ugd��+ A� Columns$+ 2��, A� Rows$, 7��$��5q� ��%/  '��       '�� A     '�� �     '�� �     �� " ��.���  � ��$ Center=���  � ��$ Center=��� " ��.���  � ��$ Center=���  � ��$ Stretch=��� " ��.���  � ��$ Center=���  � ��$ Stretch=��� " ��.���  � ��$ Center=���  � ��$ Stretch=�.+��� $��串口名称:���� -   - ��Name$- cboPortNames������ *	PortNames+. �� SelectedValue. �� *Data.PortPara.PortIndex+{��� *	IsEnabled+$( btnOpen���� $��波特率值:���� #���  ���� *Data.PortPara.BaudRate+/ �� UpdateSourceTrigger$/ PropertyChanged=�{��� *	IsEnabled+$( btnOpen���� $��编码格式:���� -   $- cboEncodings������ *	Encodings+. �� *Data.PortPara.EncodingIndex+{��� *	IsEnabled+$( btnOpen���� $��奇偶校验:���� -   $- cboParities������ *
Parities+0 �� SelectedIndex0 �� *Data.PortPara.ParityIndex+{��� *	IsEnabled+$( btnOpen���� $��数据位值:���� #���  ���� *Data.PortPara.DataBits+$ TwoWay=�$/ PropertyChanged=�{��� *	IsEnabled+$( btnOpen���� $��停止位值:���� -   $- cboStopBites������ *
StopBitses+0 �� *Data.PortPara.StopBitsIndex+{��� *	IsEnabled+$( btnOpen���� -   $) btnOpen��$��启动端口���� -   $) btnClose��$��停止端口��{�.  �� $��操作命令��$��1��$��1��
���iii�$��5q�$��1q�$��2��.���  �� $��* ��� $��* ��� $��* ��� $��* � �� -   1 ��Name$	1 row��$��* ��� $
��auto ��� $
��auto �.+��� $��0��$��4��$
��Auto=�.���� 
����������� *
Data.Funcs+$ TwoWay=����� .R�� 2 � Orientation$2 
Horizontal=����� .R��� $	) btn��-   $��5q�$��40������ *	Content+
3 � Tag3 �� *	Command+4 � ToolTip4 �� *	Command+�� $��0��$��4��$
��Auto=�y��� *	IsChecked+$( btnEdit��5 �� 	Converter#5 [  .���� 
�������y��� *	IsChecked+$( btnEdit��#5 [  ���� *
Data.Funcs+$ TwoWay=����� .R�� $2 
Horizontal=����� .R��� 
���iii�$��1q�$
 3��$��5q�$��40��._��  �� �� .+��� $��Stretch=�$��Center=�$��0������ *	Content+�� $��Stretch=�$��Center=�$��1������ *	Command+�� $��0��$��4��$
��Auto=�y��� *	IsChecked+$( btnDel��#5 [  .���� 
�������$
��Auto=�y��� *	IsChecked+$( btnDel��#5 [  ���� *
Data.Funcs+$ TwoWay=����� .R�� $2 
Horizontal=����� .R��� $) btndel��-   
���iii�$��1q�$��5q�.���  �� �� .+��� $��Center=�$��Center=�$��0������ *	Content+6 �� StringFormat$6 
名称:{0}���� $��Center=�$��Center=�$��1������ *	Command+$6 
命令:{0}��F� +����        �@B @B �@B     �    @B 	7 �� Stretch$
7 Fill=�$��50��$��30��$��Center=�$��Center=�
���  ��$��2��$��2���� $��1��$��4��$
 2,2,0,0��$��1��
���iii�$��1,1,1,0q�8 �� Padding$8 1q�._��  �� $��* ��� $��3* ��� $��* ��� $��* ��� $��* � ��%�   '��       '�� A     �� " ��.���  � ��$ Center=���  � ��$ Center=��� " ��.���  � ��$ Center=���  � ��$ Stretch=�.+��� $��功能名称:��$��0���� -   $' 
txtContent��$��1��$��0,0,2,0q�$��Stretch=�#���  �� -   $) btnAdd��$��添加��$��2������ " ��9 �� Triggers9 �� : �� Binding: �� *	IsChecked+$( btnEdit��; �� Value; true.a���  � {� .  �� : �� *	IsChecked+$( btnDel��; true.a���  � {� .  d� -   < d�Name$< btnEdit��$��编辑��$��3������ " d�9 �� : �� *	IsChecked+$( btnDel��; true.a���  � {� .  d� -   $< btnDel��$��删除��$��4������ " d�9 �� : �� *	IsChecked+$( btnEdit��; true.a���  � {� .  �� $��2��$��4��$
 0,0,2,2��$��1��
���iii�$��1,0,1,1q�$8 1q�._��  �� $��* ��� $��3* ��� $��* ��� $��* ��� $��* �.+��� $��操作命令:��$��0��$��Center=�$��Center=��� -   $' txtSend��$��Center=�$��Stretch=�$��1��#���  $��0,0,2,0q��� -   $) btnSend��$��发送��$��2��$��3��{��� *	IsEnabled+$( btnClose��