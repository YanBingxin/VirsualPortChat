   M S B A M L   `   `   `  ���� H  DVirsualDevice, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:VirsualDeviceVirsualDevice  \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089   FocusedBorderBrush  �� Color  MouseOverBackground  ClearButtonTemplate �� 
TargetType ��Name �� RelativeSource �� Triggers P� Property P� Value �� 
TargetName �� Value	 �� Property  DownClearButtonTextBoxStyle
 �� 
TargetType ��Name J� SnapsToDevicePixels ��Name ��Name �� Value �� Binding �� Path  
BaseButton  BaseRepeatButton  SliderStyle � RowDefinitions m�Name m� Fill m� 	Placement F�Name �� Stretch ]�Name ]� DecreaseRepeatButton ]� IncreaseRepeatButton ]� Thumb n�Name � OverridesDefaultStyle � UseLayoutRounding �� Triggers  � ColumnDefinitions�� D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    :x,http://schemas.microsoft.com/winfx/2006/xaml     %localclr-namespace:VirsualDevice  %�   &	        &	      &	 &     &	 +    &	     &	 �    &	 �    �� $  Black���� $  	LightGray���� " ��.R�� .+��� $ 	rctButton��
������ $��Stretch=�$��Stretch=��� $��Center=�$��Center=����� *	Content+ �� *TemplatedParent+ P�  �@J�IsMouseOver . . ��� $ 	rctButton��# �  	 � ���� 	 � ��
 ������� "
 ��.��� 	 � �� �� " ��.R��� $ bdRoot��#��z��#��z��# z #��z��._�]� ��. .+��� $ Part_ClearButton��$��清空日志��$��Bottom=�|�.  $
��auto��#���  #��z���� $ PART_ContentHost��$	��Top=�#��z�� �� $  �� ��  �� *Self+$
 Text�.a��� $ Part_ClearButton��	 � y�$ 	Collapsed=�P�  �@J�	IsFocused . . ��� $ bdRoot��# �   	 � ��P�  �@J�IsMouseOver . . ��� $ bdRoot��# �   	 � ���� " ��.R��� $ gd��
�������$	��0.5q�
�������._��� #��z��#��z��$��Center=�$��Center=� P�  �@J�IsMouseOver . . ��� 	 � ��
 ������� $ gd��	 � ��
 �iii��� " ��.R��� $ gd��
�������$	��0.5q�
�������._��� $��16(�#��z��$��Center=�$��Center=� P�  �@J�IsMouseOver . . ��� 	 � ��
 ������� $ gd��	 � ��
 �iii��� "
 ��.��� 	 �@��IsPressAndHoldEnabled .  �� 	 � ��
 ���� �� 	 � ��
 ���� �� 	 � �� �	#FFE5E5E5�� 	 � �� �� " ��.R��� $ border��#��z��#��z��#��z�� . ._�� $��	0,0,199,0q� �� $
��Auto ��� $
��Auto �#��z���� $
��Auto �.+�m� $ TopTick��# z��$��4��$��0,0,0,2q�$	 Top=�$��0��$y�	Collapsed=�m� $ 
BottomTick��# z��$��4��$��0,2,0,0q�$ Bottom=�$��2��$y�	Collapsed=�F� $ TrackBackground��
�������$
 Fill=�
�������"����        �@B �����@B     	$��8��$	��5,0q�$��1��$��Center=��� $ TrackBackgrounds�����	#FFD6D6D6$��1q����	#FFE7EAEA$��4��$	��5,0q�$��1��$��Center=�$y�	Collapsed=�._��� $��-6,-1q�.+��� $ PART_SelectionRange��#��� ��$��4��$y�Hidden=�]� $ 
PART_Track��$��1�� �� $��Slider.DecreaseLarge������ "
 ��.��� 	 �@�OverridesDefaultStyle . �� 	 � ��
 ���� �� 	 � |� .  �� 	 � �� .  �� 	 � �� �� " ��.R��� #��z��#��z��#��z�� �� $��Slider.IncreaseLarge������ "
 ��.��� 	 �@�OverridesDefaultStyle . �� 	 � ��
 ���� �� 	 � |� .  �� 	 � �� .  �� 	 � �� �� " ��.R��� #��z��#��z��#��z�� n� $ Thumb��|�.  $��18�� . $��Center=�$��11������ " n�.R�� $��Center=� . $��Center=�.+�F� $
 grip��d����        �        �ا �ا ��ا     �ا ���ا ����ا �������    ��	
�������$
 Fill=� . ���	#FFACACAC$��1�� . $��Center=� P�  �@J�IsMouseOver . . ��� $
 grip��	 � ��
 ������� $
 grip��	 � ��
 �����P�  �@n�
IsDragging . . ��� $
 grip��	 � ��
 ������� $
 grip��	 � ��
 �����P�  � {� .  . ��� $
 grip��	 � �� �	#FFF0F0F0�� $
 grip��	 � �� �	#FFD9D9D9 P�  �@��TickPlacement$ TopLeft=�. ��� $ TopTick��	 � y�$ Visible=��� $ Thumb��	 � �� �� " n�.R�� $��Center=� . $��Center=�.+�F� $
 grip�������    ��[ �    ��[ `�S `�S �`�S     �ا ��[ �ا ��[ ��ا ��[ �ا ���ا ����ا �������    ����[ ��[ 	���	#FFF0F0F0$
 Fill=� . ���	#FFACACAC$��1�� . $��Center=� P�  �@J�IsMouseOver . . ��� $
 grip��	 � �� �	#FFDCECFC�� $
 grip��	 � �� �	#FF7EB4EAP�  �@n�
IsDragging . . ��� $
 grip��	 � �� �	#FFDAECFC�� $
 grip��	 � �� �	#FF569DE5P�  � {� .  . ��� $
 grip��	 � �� �	#FFF0F0F0�� $
 grip��	 � �� �	#FFD9D9D9�� $ TrackBackground��	 � ��$ 5,2,5,0q�P�  �@��TickPlacement$ BottomRight=�. ��� $ 
BottomTick��	 � y�$ Visible=��� $ Thumb��	 � �� �� " n�.R�� $��Center=� . $��Center=�.+�F� $
 grip�������     � �     � `�S ��`�S ���`�S ���ا  � �ا  � ��ا  � �ا �ا ��ا     �         �  � 	
�������$
 Fill=� . ���	#FFACACAC$��1�� . $��Center=� P�  �@J�IsMouseOver . . ��� $
 grip��	 � ��
 �iii��� $
 grip��	 � ��
 �iii�P�  �@n�
IsDragging . . ��� $
 grip��	 � ��
 �iii��� $
 grip��	 � ��
 �iii�P�  � {� .  . ��� $
 grip��	 � �� �	#FFF0F0F0�� $
 grip��	 � �� �	#FFD9D9D9�� $ TrackBackground��	 � ��$ 5,0,5,2q�P�  �@��TickPlacement$
 Both=�. ��� $ TopTick��	 � y�$ Visible=��� $ 
BottomTick��	 � y�$ Visible=�P�  �@��IsSelectionRangeEnabled . . ��� $ PART_SelectionRange��	 � y�$ Visible=�P�  �@J�IsKeyboardFocused . . ��� $ Thumb��	 � ��
 ��  � P�  �@��Orientation$ Vertical=�. ��� 	 � �� �� " ��.R��� $ border��#��z��#��z��#��z�� . ._��   �� $
��Auto ��� #��z��$
��Auto ��� $
��Auto �.+�m� $ TopTick��$��0��# z��$��0,0,2,0q�$
 Left=�$y�	Collapsed=�$��4��m� $ 
BottomTick��$��2��# z��$��2,0,0,0q�$ Right=�$y�	Collapsed=�$��4���� $ TrackBackground�����	#FFD6D6D6$��1q����	#FFE7EAEA$��1��$��Center=�$	��0,5q�$��4��._��� $��-1,-6q�.+��� $ PART_SelectionRange��#��� ��$y�Hidden=�$��4��]� $ 
PART_Track��$��1�� �� $��Slider.DecreaseLarge������ "
 ��.��� 	 �@�OverridesDefaultStyle . �� 	 � ��
 ���� �� 	 � |� .  �� 	 � �� .  �� 	 � �� �� " ��.R��� #��z��#��z��#��z�� �� $��Slider.IncreaseLarge������ "
 ��.��� 	 �@�OverridesDefaultStyle . �� 	 � ��
 ���� �� 	 � |� .  �� 	 � �� .  �� 	 � �� �� " ��.R��� #��z��#��z��#��z�� n� $ Thumb��|�.  $��11�� . $	��Top=�$��18������ " n�.R�� $��Center=� . $��Center=�.+�F� $
 grip��+���� �  � ѠI � ѠI�y� � � �y� 	���	#FFF0F0F0$
 Fill=����	#FFACACAC P�  �@J�IsMouseOver . . ��� $
 grip��	 � �� �	#FFDCECFC�� $
 grip��	 � �� �	#FF7EB4EAP�  �@n�
IsDragging . . ��� $
 grip��	 � �� �	#FFDAECFC�� $
 grip��	 � �� �	#FF569DE5P�  � {� .  . ��� $
 grip��	 � �� �	#FFF0F0F0�� $
 grip��	 � �� �	#FFD9D9D9 P�  �@��TickPlacement$ TopLeft=�. ��� $ TopTick��	 � y�$ Visible=��� $ Thumb��	 � �� �� " n�.R�� $��Center=� . $��Center=�.+�F� $
 grip���������[ �ا Ӏ�[ �ا `�S `�S �    `�S ��[ ��[ Ӏ�[     ����Ӏ�    ���ا ���ا Ӏ��ا ��[ �ا ��[ �ا 	���	#FFF0F0F0$
 Fill=����	#FFACACAC P�  �@J�IsMouseOver . . ��� $
 grip��	 � �� �	#FFDCECFC�� $
 grip��	 � �� �	#FF7EB4EAP�  �@n�
IsDragging . . ��� $
 grip��	 � �� �	#FFDAECFC�� $
 grip��	 � �� �	#FF569DE5P�  � {� .  . ��� $
 grip��	 � �� �	#FFF0F0F0�� $
 grip��	 � �� �	#FFD9D9D9�� $ TrackBackground��	 � ��$ 2,5,0,5q�P�  �@��TickPlacement$ BottomRight=�. ��� $ 
BottomTick��	 � y�$ Visible=��� $ Thumb��	 � �� �� " n�.R�� $��Center=� . $��Center=�.+�F� $
 grip������� � �ا � � �ا ��`�S ��`�S Ӏ�`�S  �  � � �     �        �ا �ا �    �ا  � �ا  � �ا 	���	#FFF0F0F0$
 Fill=����	#FFACACAC P�  �@J�IsMouseOver . . ��� $
 grip��	 � �� �	#FFDCECFC�� $
 grip��	 � �� �	#FF7EB4EAP�  �@n�
IsDragging . . ��� $
 grip��	 � �� �	#FFDAECFC�� $
 grip��	 � �� �	#FF569DE5P�  � {� .  . ��� $
 grip��	 � �� �	#FFF0F0F0�� $
 grip��	 � �� �	#FFD9D9D9�� $ TrackBackground��	 � ��$ 0,5,2,5q�P�  �@��TickPlacement$
 Both=�. ��� $ TopTick��	 � y�$ Visible=��� $ 
BottomTick��	 � y�$ Visible=�P�  �@��IsSelectionRangeEnabled . . ��� $ PART_SelectionRange��	 � y�$ Visible=�P�  �@J�IsKeyboardFocused . . ��� $ Thumb��	 � ��
 ��  �