   M S B A M L   `   `   `  ���� E  AGidonitApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:GidonitApp
GidonitApp  O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089I2clr-namespace:System.Collections;assembly=mscorlibSystem.Collections     GidonitApp.MainWindow   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     *localclr-namespace:GidonitApp     Bcol2clr-namespace:System.Collections;assembly=mscorlib     -     � Title$  
MainWindow�� � WindowStyle$
 None=�$	��793��$
��1366��$��11175��$	��793��$
��1366��$	��793�� � Icon$E ?/!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!.png��
������  � AllowsTransparency .  � 	Resources    ComboBoxToggleButton �� 
TargetType � ColumnDefinitions ��Name �� CornerRadius	 F�Name  ComboBoxTextBox
 �� 
TargetType �� Property �� Value �� 	ClickMode d� 	IsChecked �� Path �� Mode �� RelativeSource J� IsHitTestVisible �� SelectionBoxItem �� SelectionBoxItemTemplate ��Name �� 
IsReadOnly �� 
IsReadOnly �� IsDropDownOpen � AllowsTransparency J� SnapsToDevicePixels � ActualWidth �� MaxDropDownHeight K� IsItemsHost-  'System.Windows.Input.KeyboardNavigation   DirectionalNavigation �� Triggers  P� Property! P� Value" �� 
TargetName# P� 
SourceName$ �� Triggers% �� Padding  ScrollBarLineButtonStyle " ScrollBarLineButtonBottomStyle  ScrollBarPageButtonStyle  ScrollBarThumbStyle& �� RadiusX' �� RadiusY  VerticalScrollBar( � RowDefinitions) ]� DecreaseRepeatButton* ]� Thumb+ ]� IncreaseRepeatButton  myCheckboxStyle, �� Orientation- ��Name. ]� 
Conditions/ �� Property0 �� Value  TextBox.Static.Border1 �� Color 	 TextBox.MouseOver.Border 
 TextBox.Focus.Border  TextBoxStyle12 ��Name��%Q  &	        &	 =    '�� t    7   7  '�� �    &	     &	 O    &	 �    &	 �    &	 �	    7  7  7  7  7  '�� �
    7  &	 �
    &	 )    &		 >    &	
 S    &	 h    7  7 	 7 
 �� " d�.R��  �� �� $��20 �.+��� $ Border��$��2��$ 0�����#101724���	#FF97A0A5$��1q��� $��0��$ 0��$��1q����#101724���	#FF97A0A5$��0,0,1,0q�F� $	 Arrow��$��1��
�������$��Center=�$��Center=�=����        �    �� � 	= ��[ � z �� � z     � 	=  	= 	�� " ��.R��� $ PART_ContentHost��|�.  #��z���� "
 ��.���  �@J�SnapsToDevicePixels . ��  �@�OverridesDefaultStyle . ��  � ��$
 Auto=���  � ��$
 Auto=���  � �� . ��  � ��$	 120����  � ��$ 20����  � ��
 �������  � �� �� " ��.R�� .+�d� $��ToggleButton��8��  $��2��|�.  $ Press=� �� $ IsDropDownOpen�$ TwoWay=� �� *TemplatedParent+�� $��ContentSite�� .  #��z #��z #��z��$��3,3,23,3q�$��Center=�$
��Left=��� $ PART_EditableTextBox��8�� $
��Left=�$��Center=�$��3,3,23,3q�|�. ���#101724
��� � �$y�Hidden=�# z ��Z� � $��Popup��$��Bottom=�#��z  . |�.  $��Slide=�.��� $��DropDown�� . #��z #��z .+��� $ DropDownBorder�����#101724$��1q����#888888�� $��4,6,4,6q� . .����  . $ 	Contained=� P�   �@��HasItems! .  . ��� $" DropDownBorder�� � ��$ 95��P�   � {�! .  . ���  � �� �#888888P�   �@��
IsGrouping! . . ���  � �� .  P� $# Popup��  �@�AllowsTransparency! . . ��� $" DropDownBorder�� �@��CornerRadius$ 0���� $" DropDownBorder�� � ��$ 0,2,0,0q�P�   �@��
IsEditable! . . ���  � �� .  �� $" PART_EditableTextBox�� � y�$ Visible=��� $" ContentSite�� � y�$ Hidden=�$ �� "
 ��.���  �@J�SnapsToDevicePixels . ��  � ��
 �������  �@�OverridesDefaultStyle . ��  � �� �� " ��.R��� $��Border��$% 2q� . ._���  P�   �@��IsHighlighted! . . ��� $" Border�� � �� �	#FF4F4F4FP�   � {�! .  . ���  � �� �#888888�� "
 ��.���  � |� .  ��  � �� �� " ��.R��� $��0���� "
 ��.���  � |� .  ��  � �� �� " ��.R��� $��0���� "
 ��.���  � �� .  ��  � |� .  ��  � �� �� " ��.R��� 
������ �� "
 n�.���  � �� .  ��  � |� .  ��  � ��$ 1,0,1,0q���  � �� �� " n�.R��� $��7�����#494d74$	& 3.5��$	' 3.5���� " ��.R�� ( �� $��0* ��� $��1* ��� $��0* �.+��� $��0��$��18��8��  $��ScrollBar.LineUpCommand��]� $��
PART_Track��$��1����. ) �� $��ScrollBar.PageUpCommand��8�� * n� 8�� + �� $��ScrollBar.PageDownCommand��8�� �� $��3��$��18��8�� $��ScrollBar.LineDownCommand���� "
 ��.���  � ��8   �� "
 ��.���  � �� �� " ��.R��� $, 
Horizontal=�.+��� $- checkboxImage��$��/CB_norm.png��$��10����  P�   �@d�	IsChecked$
! TrueY�. ��� $" checkboxImage�� � ��$ /CB_checked.png��]� . �� / �@J�IsMouseOver0 . �� / �@d�	IsChecked$0 FalseY��� $1 	#FFABAdB3���� $1 	#FF7EB4EA���� $1 	#FF569DE5���� "
 ��.���  � ��# � ����  � ��8   ��  � ��# � ����  � ��$ 1q���  �@ TabNavigation$
 None=���  � ��$
 Left=���  �@�FocusVisualStyle Z� ��  �@J�	AllowDrop . ��  �@��PanningMode$ VerticalFirst=���  �@��IsFlicksEnabled .  ��  � �� �� " ��.R��� $ border��$ 6��#��z��#��z��#��z�� . ._��� $2 PART_ContentHost��|�.  $��Hidden=�$��Hidden=� P�   � {�! .  . ��� $" border�� �@J�Opacity$
 0.56Q�P�   �@J�IsMouseOver! . . ��� $" border��8   � ��P�   �@J�IsKeyboardFocused! . . ��� $" border��8   � ��$ ]� . �� +/ �@��#IsInactiveSelectionHighlightEnabled0 . �� / �@��IsSelectionActive0 .  ./���  �@��SelectionBrush# � /�.��� ���� "
 �.���  �@�ShowGridLines .  ( �� $��25 ��� $	��768 �.+�� -   $��0�� �� $��1266* ��� $	��25* ��� $��1* ��� $	��25* ��� $��5* ����� 3 �� ImageSource$3 /TopPanel.png��.+��� -   $��3��$��17��$��17��
�������$��0q�$��DemiBold"�$��15(�$��Center=�$��Center=����� "
 ��.���  � ��
 ���� ��  � �� �� " ��.R��� #��z��._��� $��Center=�$��Center=�$ P�   �@J�IsMouseOver! . . ���  � ��
 �  ��.���� $��
/Close.png���� -   $��1��$��17��$��17��
�������$��0q�$��DemiBold"�$��15(�$��Center=�$��Center=����� "
 ��.���  � ��
 ���� ��  � �� �� " ��.R��� #��z��._��� $��Center=�$��Center=�$ P�   �@J�IsMouseOver! . . ���  � �� �	#FF2E2969.���� $��	/hide.png��� $��1�� �� $	��50* ��� $
��633* �.+��� -   $- 
Background��$��/Background.png��$��2���� -   $
- Dark��$y�Visible=�$��2��� -   $��
MinterMenu��$��1��.+�� -   $��MintModuleSettings��$y�Hidden=� �� $	��53* ��� $
��158* �.+�� $��1��( �� $	��58* ��� $
��539* ��� $	��55* ��� $	��53* ��� $	��63* � �� $
��101* ��� $
��765* ��� $	��82* �.+�� $��3��$��1�� �� $
��426* ��� $
��138* ��� $	��32* ��� $
��138* ��� $	��31* �.+��� -	   $��ConfimrmMint��$��3������ "
 ��.���  � ��$ ConfirmWallet.png��$ P�   �@J�IsMouseOver! . . ���  � ��$ ConfirmWallet_hover.png���� -
   $��
CancelMint��$��1������ "
 ��.���  � ��$ CancelWallet.png��$ P�   �@J�IsMouseOver! . . ���  � ��$ CancelWallet_hover.png��&   System.Windows.Controls.DataGrid  -   $��ActiveWallets��4   RowBackground
4 ���� $��1��$��1��5   HeadersVisibility$5 Column=�$��Visible=�$��Hidden=���. 6   CanUserResizeColumns6 .  7   	RowHeight$7 43Q�8   GridLinesVisibility$
8 None=�$��1,1,1,1q�9   ColumnHeaderHeight$9 43Q�
������ :   CanUserAddRows: .  ;   CanUserDeleteRows; .  <   CanUserReorderColumns< .  =   CanUserSortColumns= .  >   AutoGenerateColumns> .  ?   
IsReadOnly? . @   EnableRowVirtualization@ .  A   CanUserResizeRowsA .  ��Z� B   	CellStyleB �� *  $System.Windows.Controls.DataGridCell"
  .���  � ��
 ���� ��  � �� �#25222b��  � ��$ 0,0,0,1q�C   ColumnHeaderStyleC �� =  7System.Windows.Controls.Primitives.DataGridColumnHeader"
  .���  � ��$ 0,0,0,1q���  � ��
 ���� ��  � �� �#25222bD   ColumnsD 4  .System.Windows.Controls.DataGridTemplateColumn  -   
ADselected��,  &System.Windows.Controls.DataGridColumnE   Width5  /System.Windows.Controls.DataGridLengthConverter$	E 585 F   CellTemplateF �� .R��� 
�������$	��430��$��20�� . G �� TextAlignment$G Center=�$	��430��
������ 
������ .������ "
 ��.���  � �� �� *
hiddenAddr+$ P�   �@J�IsMouseOver! . . ���  � �� �� *	address+P�   �@J�	IsFocused! . . ���  � �� �� *	address+.��H   HeaderH �� $��	250,0,0,0q�$��Center=�$��Center=�$��Address��$��20(�
�������$��Center=�  -   BalSelected��$	E 160 F �� .R��� 
�������$��80��$��20�� . $G Center=�$��80��
������ 
������ ���� *	balance+H �� $��40,0,0,0q�$��Center=�$��Center=�$��Balance��$��20(�
�������� $��0��( �� $	��59* ��� $	��37* ��� $	��21* ��� $	��37* ��� $	��21* ��� $	��37* ��� $	��21* ��� $	��37* ��� $	��21* ��� $	��37* ��� $	��21* ��� $	��37* ��� $	��21* ��� $	��37* ��� $
��350* � �� $	��29* ��� $
��130* �.+��� -   $��MintType��$��1��$��1��I �� SelectedIndex$I 0��.@��� -   $��Item1��.��Public�� -   $��Item2��.��WL�� -   $��Item3��.��OG�� $��Select type of mint here��$��10(�
�������$��1��$��2��$��Center=�$��Center=�$	��Top=�$��2���� -   $��	MintPrice�����#dadada$��16(�#���  
������ ���#26262b$��3��$��1��$��Center=��� $��Write here MintPrice��$��10(�
�������$��1��$��4��$��Center=�$��Center=�$	��Top=�$��2���� -   $��GasUP��$	��100�����#dadada$��16(�#���  
������ ���#26262b$��5��$��1��$��Center=��� $��Write here Gas Unit Price��$��10(�
�������$��1��$��6��$��Center=�$��Center=�$	��Top=�$��2���� -   $��GasMax��$��90000�����#dadada$��16(�#���  
������ ���#26262b$��7��$��1��$��Center=��� $��Write here max gas amount��$��10(�
�������$��1��$��8��$��Center=�$��Center=�$	��Top=�$��2���� -   $��ModAddr�����#dadada$��16(�#���  
������ ���#26262b$��9��$��1��$��Center=��� $4��.Write here address of mint module(check guide)��$��10(�
�������$��1��$��10��$��Center=�$��Center=�$	��Top=�$��2���� -   $��MintTime�����#dadada$��16(�#���  
������ ���#26262b$��11��$��1��$��Center=�J � 
InputScope$
J Time���� $6��0Write here time, when to start(format: hh-mm-ss)��$��10(�
�������$��1��$��12��$��Center=�$��Center=�$	��Top=�$��2���� -   $��CollectionName�����#dadada$��16(�#���  
������ ���#26262b$��13��$��1��$��Center=��� $(��"Write here full name of collection��$��10(�
�������$��1��$��14��$��Center=�$��Center=�$	��Top=�$��2��� -   $��MinterSelection��$y�Hidden=� �� $
��118* ��� $��1151* �( �� $
��122* ��� $	��83* ��� $	��63* ��� $	��31* ��� $	��63* ��� $	��31* ��� $	��63* ��� $	��31* ��� $	��63* ��� $	��31* ��� $	��63* ��� $
��129* �.+��� $��34(�$��Mint Modules Selection��
�������$��1��$��1���� -   $��Topaz��$��2��$��1��$	��230��$��63��$
��Left=����� "
 ��.���  � ��$ /TopazMinterButton.png��$ P�   �@J�IsMouseOver! . . ���  � ��$" /TopazMinterButton_hover.png���� -   $��Souffl3��$��4��$��1��$	��230��$��63��$
��Left=����� "
 ��.���  � ��$ /Souffl3MinterButton.png��$ P�   �@J�IsMouseOver! . . ���  � ��$$ /Souffl3MinterButton_hover.png���� -   $��Lmnft��$��6��$��1��$	��230��$��63��$
��Left=����� "
 ��.���  � ��$ /LMNFTMinterButton.png��$ P�   �@J�IsMouseOver! . . ���  � ��$" /LMNFTMinterButton_hover.png���� -   $��BlueMove��$��8��$��1��$	��230��$��63��$
��Left=����� "
 ��.���  � ��$ /BlueMoveMinterButton.png��$ P�   �@J�IsMouseOver! . . ���  � ��$% /BlueMoveMinterButton_hover.png���� -   $��Candy��$��10��$��1��$	��230��$��63��$
��Left=����� "
 ��.���  � ��$ /CandyMinterButton.png��$ P�   �@J�IsMouseOver! . . ���  � ��$" /CandyMinterButton_hover.png��� -   $��
SniperMenu��� -   K �Name$K Menu_Buttons��$��0��( �� $	��75* ��� $	��26* ��� $	��26* ��� $	��26* ��� $	��27* ��� $	��71* �.+��� -    $- 
Minter_bot��$��1��$��89��$��94������ "
 ��.���  � ��$! Minter_bot_button_menu1.png��$ P�   �@J�IsMouseOver! . . ���  � ��$&  Minter_bot_button_menu_hover.png���� -!   $- Sniper��$��2��$��50��$��50������ "
 ��.���  � ��$ /sniperMenuButton.png��$ P�   �@J�IsMouseOver! . . ���  � ��$! /sniperMenuButton_hover.png���� -"   $- Wallets��$��3��$��50��$��50������ "
 ��.���  � ��$ /wallets_button.png��$ P�   �@J�IsMouseOver! . . ���  � ��$ /wallets_button_hover.png���� -#   $- Settings��$��4��$��50��$��50������ "
 ��.���  � ��$ /settings.png��$ P�   �@J�IsMouseOver! . . ���  � ��$ /settings_hover.png��� -$   $K Wallets_Menu��$y�Visible=�
������ $��1��.+�� ( �� $	��34* ��� $	��35* ��� $	��95* ��� $
��577* ��� $	��63* �.+�� -%   $K Wallet_Manager_Buttons��$��1�� �� $
��219* ��� $
��133* ��� $	��21* ��� $
��133* ��� $	��21* ��� $
��133* ��� $	��21* ��� $
��133* ��� $	��21* ��� $
��133* ��� $	��21* ��� $
��133* ��� $
��148* �.+��� -&   $- ImportButton��$��1������ "
 ��.���  � ��$ ImportButton.png��$ P�   �@J�IsMouseOver! . . ���  � ��$ ImportButton_hover.png���� -'   $- ExportButton��$��3������ "
 ��.���  � ��$ ExportButton.png��$ P�   �@J�IsMouseOver! . . ���  � ��$ ExportButton_hover.png���� -(   $- CollectButton��$��5������ "
 ��.���  � ��$ CollectWallet.png��$ P�   �@J�IsMouseOver! . . ���  � ��$ CollectWallet_hover.png���� -)   $- Distributton��$��7������ "
 ��.���  � ��$ DistribWallet.png��$ P�   �@J�IsMouseOver! . . ���  � ��$ DistribWallet_hover.png���� -*   $- 	GenButton��$��9������ "
 ��.���  � ��$ GenWallet.png��$ P�   �@J�IsMouseOver! . . ���  � ��$ GenWallet_hover.png���� -+   $- 
RefreshBal��$��11������ "
 ��.���  � ��$ /RefreshBal.png��$ P�   �@J�IsMouseOver! . . ���  � ��$ /RefreshBal_hover.png��� $��3�� �� $
��150* ��� $��1067* ��� $	��50* �.+�  -,   L  Name$L WalletsList��
4 ���� $��1��$5 Column=�$��Visible=�$��Hidden=���. 6 .  $7 43Q�$
8 None=�$��1,1,1,1q�$9 43Q�
������ : .  ; .  < .  = .  > .  ? . @ .  A .  $	��577��$	��557����Z� B �� "
  .���  � ��
 ���� ��  � �� �#25222b��  � ��$ 0,0,0,1q�C �� "
  .���  � ��$ 0,0,0,1q���  � ��
 ���� ��  � �� �#25222bD   M   SortMemberPath$M CB��--   CBA��$E 43 F �� .R��� #��[ $��16,0,0,0q� �� *CB+$ TwoWay=�N �� UpdateSourceTrigger$N PropertyChanged=�H �� -.   O ��Name$O 	checkBox1��#��[ $��16,0,0,0q�$��Center=�$��Center=�  -/   Name��$	E 170 $
M name��F �� .R��� 
�������$��80��$��20�� . $G Center=�$��80��
������ 
������ ���� *name+H �� $��50,0,0,0q�$��Center=�$��Center=�$
��Name��$��20(�
�������  -0   PK��$	E 220 $M 
privateKey��F �� .R��� 
�������$	��180��$��20�� . $G Center=�$	��345��
������ 
������ .������ "
 ��.���  � �� �� *
hiddenPK+$ P�   �@J�IsMouseOver! . . ���  � �� �� *
privateKey+P�   �@J�	IsFocused! . . ���  � �� �� *
privateKey+.��H �� $��60,0,0,0q�$��Center=�$��Center=�$��Private Key��$��20(�
�������  -1   AD��$	E 220 $M address��F �� .R��� 
�������$	��180��$��20�� . $G Center=�$	��345��
������ 
������ .������ "
 ��.���  � �� �� *
hiddenAddr+$ P�   �@J�IsMouseOver! . . ���  � �� �� *	address+P�   �@J�	IsFocused! . . ���  � �� �� *	address+.��H �� $��70,0,0,0q�$��Center=�$��Center=�$��Address��$��20(�
�������  -2   NFT��$	E 100 $M address��F �� .R��� 
�������$��80��$��20�� . $G Center=�$��80��
������ 
������ ���� *NFT+H �� $��28,0,0,0q�$��Center=�$��Center=�$	��NFT��$��20(�
�������  -3   BL��$	E 160 $M balance��F �� .R��� 
�������$��80��$��20�� . $G Center=�$��80��
������ 
������ ���� *	balance+H �� $��40,0,0,0q�$��Center=�$��Center=�$��Balance��$��20(�
�������  $E 53 $
M send��-4   send��F �� .R��� -5   $��25��$��25������ "
 ��.���  � ��$ SendButton.png��$ P�   �@J�IsMouseOver! . . ���  � ��$ SendButton_hover.png��H �� $��25,0,0,0q�$��Center=�$��Center=�  $E 58 $
M edit��F �� .R��� -6   $��25��$��25������ "
 ��.���  � ��$ EditButton.png��$ P�   �@J�IsMouseOver! . . ���  � ��$ EditButton_hover.png��H �� $��25,0,0,0q�$��Center=�$��Center=�  $E 29 $	M del��F �� .R��� -7   $��25��$��25������ "
 ��.���  � ��$ DelWallet.png��$ P�   �@J�IsMouseOver! . . ���  � ��$ DelWallet_hover.png��H �� $��25,0,0,0q�$��Center=�$��Center=��� -8   P ��Name$P 
AddingMenu��$y�Hidden=�$	��580��$	��401��$��0,20,0,0q����� $3 /AddingMenu.png��.+�� .+��� -9   $ PrivateKeyInput��
�������$�� ��$��35,112,42,-122q�$��0q�$	��229��Q �� AcceptsReturnQ . .������ R �� EndPoint$	R 1,0&�S �� 
StartPoint$	S 0,0&�T � ColorInterpolationMode$T SRgbLinearInterpolation=�U � MappingMode$U RelativeToBoundingBox=�V � SpreadMethod$	V Pad=�.��� W � Color$W #0c0a24��� $W #280d30��X � Offset$X 1Q�.���� -:   $��25��$��476,361,26,-167q�$��79������ "
 ��.���  � ��$ ConfirmWallet.png��$ P�   �@J�IsMouseOver! . . ���  � ��$ ConfirmWallet_hover.png���� -;   $��25��$��368,361,133,-167q�$��79������ "
 ��.���  � ��$ CancelWallet.png��$ P�   �@J�IsMouseOver! . . ���  � ��$ CancelWallet_hover.png���� -<   $P 
ExportMenu��$y�Hidden=�$	��580��$	��401��$��0,20,0,0q����� $3 /ExportMenu.png��.+�� .+��� -=   $ PrivateKeyExport��
�������$�� ��$��35,112,42,-122q�$��0q�$	��229��Q .  . .������ $	R 1,0&�$	S 0,0&�$T SRgbLinearInterpolation=�$U RelativeToBoundingBox=�$	V Pad=�.��� $W #0c0a24��� $W #280d30��$X 1Q�.���� ->   $��25��$��459,361,42,-167q�$��79������ "
 ��.���  � ��$ CancelWallet.png��$ P�   �@J�IsMouseOver! . . ���  � ��$ CancelWallet_hover.png���� -?   $P editingWallet��$y�Hidden=�$	��580��$	��401��$��0,20,0,0q����� $3 /EditMenu.png��.+�� .+��� -@   $ newName��
�������$��25��Y �� TextWrapping$
Y Wrap=�$�� ��$	��350��$��
0,-150,0,0q�Z �� IsUndoEnabledZ .  ��Z� .������ $	R 1,0&�$	S 0,0&�$T SRgbLinearInterpolation=�$U RelativeToBoundingBox=�$	V Pad=�.��� $W #0c0a24��� $W #280d30��$X 1Q�.���� -A   $��25��$��454,350,0,0q�$��79������ "
 ��.���  � ��$ ConfirmWallet.png��$ P�   �@J�IsMouseOver! . . ���  � ��$ ConfirmWallet_hover.png���� -B   $��25��$��261,350,0,0q�$��79������ "
 ��.���  � ��$ CancelWallet.png��$ P�   �@J�IsMouseOver! . . ���  � ��$ CancelWallet_hover.png���� -C   $P generatingWallets��$y�Hidden=�$	��580��$	��401��$��0,20,0,0q����� $3 /GeneratingMenu.png��.+�� .+��� -D   $ countOfWallets��
�������$��25��$
Y Wrap=�$�� ��$	��350��$��
0,-150,0,0q�Z .  ��Z� .������ $	R 1,0&�$	S 0,0&�$T SRgbLinearInterpolation=�$U RelativeToBoundingBox=�$	V Pad=�.��� $W #0c0a24��� $W #280d30��$X 1Q�.���� -E   $��25��$��454,350,0,0q�$��79������ "
 ��.���  � ��$ ConfirmWallet.png��$ P�   �@J�IsMouseOver! . . ���  � ��$ ConfirmWallet_hover.png���� -F   $��25��$��261,350,0,0q�$��79������ "
 ��.���  � ��$ CancelWallet.png��$ P�   �@J�IsMouseOver! . . ���  � ��$ CancelWallet_hover.png���� -G   $P distribMenu��$y�Hidden=�$	��580��$	��401��$��0,20,0,0q����� $3 /DistribMenu.png��.+�� .+��� -H   $ privateKeyForDistrib��
�������$��25��$�� ��$	��420��$��
0,0,85,200q���Z� .������ $	R 1,0&�$	S 0,0&�$T SRgbLinearInterpolation=�$U RelativeToBoundingBox=�$	V Pad=�.��� $W #0c0a24��� $W #280d30��$X 1Q�.���� -I   $ amountDistrib��
�������$��25��$�� ��$	��420��$��
0,100,85,0q���Z� .������ $	R 1,0&�$	S 0,0&�$T SRgbLinearInterpolation=�$U RelativeToBoundingBox=�$	V Pad=�.��� $W #0c0a24��� $W #280d30��$X 1Q�.���� -J   [ ��Name$[ invalidAmount��$��Invalid amount��$��38,275,356,-164q����	#FFFF5757$y�Hidden=��� -K   $[ PrivateKeyErrorDistr��$��Invalid private key��$��
38,111,0,0q����	#FFFF5757$y�Hidden=��� -L   $[ insufficientFunds��$��Insufficient funds��$��38,255,356,-129q����	#FFFF5757$y�Hidden=��� -M   $��25��$��454,350,0,0q�$��79������ "
 ��.���  � ��$ ConfirmWallet.png��$ P�   �@J�IsMouseOver! . . ���  � ��$ ConfirmWallet_hover.png���� -N   $��25��$��261,350,0,0q�$��79������ "
 ��.���  � ��$ CancelWallet.png��$ P�   �@J�IsMouseOver! . . ���  � ��$ CancelWallet_hover.png���� -O   $P sendingMenu��$y�Hidden=�$	��580��$	��401��$��0,20,0,0q����� $3 /SendingMenu.png��.+�� .+��� -P   $ addressForSend��
�������$��25��$�� ��$	��420��$��
0,0,85,200q���Z� .������ $	R 1,0&�$	S 0,0&�$T SRgbLinearInterpolation=�$U RelativeToBoundingBox=�$	V Pad=�.��� $W #0c0a24��� $W #280d30��$X 1Q�.���� -Q   $ 
amountSend��
�������$��25��$�� ��$	��420��$��
0,100,85,0q���Z� .������ $	R 1,0&�$	S 0,0&�$T SRgbLinearInterpolation=�$U RelativeToBoundingBox=�$	V Pad=�.��� $W #0c0a24��� $W #280d30��$X 1Q�.���� -R   $[ invalidAmountSend��$��Invalid amount��$��37,249,357,-138q����	#FFFF5757$y�Hidden=��� -S   $[ AddressErrorSend��$��Invalid address��$��37,106,10,5q����	#FFFF5757$y�Hidden=��� -T   $[ insufficientFundsSend��$��Insufficient funds��$��37,264,357,-138q����	#FFFF5757$y�Hidden=��� -U   $��25��$��454,350,0,0q�$��79������ "
 ��.���  � ��$ ConfirmWallet.png��$ P�   �@J�IsMouseOver! . . ���  � ��$ ConfirmWallet_hover.png���� -V   $��25��$��261,350,0,0q�$��79������ "
 ��.���  � ��$ CancelWallet.png��$ P�   �@J�IsMouseOver! . . ���  � ��$ CancelWallet_hover.png���� -W   $P collectMenu��$y�Hidden=�$	��580��$	��401��$��0,20,0,0q����� $3 /CollectMenu.png��.+�� .+��� -X   $ collectAddress��
�������$��25��$�� ��$	��420��$��28,68,132,281q���Z� .������ $	R 1,0&�$	S 0,0&�$T SRgbLinearInterpolation=�$U RelativeToBoundingBox=�$	V Pad=�.��� $W #0c0a24��� $W #280d30��$X 1Q�.���� -Y   $[ invalidAddressCollect��$��Invalid address��$��28,105,26,10q����	#FFFF5757$y�Hidden=��� -Z   $��25��$��454,350,0,0q�$��79������ "
 ��.���  � ��$ ConfirmWallet.png��$ P�   �@J�IsMouseOver! . . ���  � ��$ ConfirmWallet_hover.png���� -[   $��25��$��261,350,0,0q�$��79������ "
 ��.���  � ��$ CancelWallet.png��$ P�   �@J�IsMouseOver! . . ���  � ��$ CancelWallet_hover.png��� -\   $K SettingsMenu��$y�Hidden=�
������ $��1�� �� $
��116* ��� $
��177* ��� $
��472* ��� $	��29* ��� $
��198* ��� $
��273* �( �� $
��105* ��� $	��69* ��� $	��59* ��� $	��50* ��� $	��72* ��� $	��50* ��� $
��362* �.+��� ���#dadada$��34(�$��Settings��$��1��$��1���� ���#dadada$��20(�$��Holder Verification��$��2��$��1���� ���#dadada$��16(�$��Auth Wallet��$��3��$��1��$��Center=�$��Center=�$��38,0,0,0q��� ���#dadada$��16(�$
��Node��$��5��$��1��$��Center=�$��Center=�$��Center=�$��36,0,0,0q��� -]   $ 
AuthWallet�����#dadada$��16(�#���  
������ ���#26262b$��3��$��2��$��Center=��� -^   $ 	NodeInput�����#fafafa$��16(�#���  
������ ���#26262b$��5��$��2��$��Center=��� -_   $��SetNewPrivateKey��$��3��$��4������ "
 ��.���  � ��$ SetNewPrivateKey.png��$ P�   �@J�IsMouseOver! . . ���  � ��$  SetNewPrivateKey_hover.png���� -`   $��SetNode��$��5��$��4������ "
 ��.���  � ��$ SetNode.png��$ P�   �@J�IsMouseOver! . . ���  � ��$ SetNode_hover.png���� -a   $- HolderNotVerified��$��/HolderNotVerified.png��$��6��$��
0,0,-100,0q�$��7��