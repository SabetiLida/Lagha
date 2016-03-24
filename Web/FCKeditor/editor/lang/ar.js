/*
 * FCKeditor - The text editor for Internet - http://www.fckeditor.net
 * Copyright (C) 2003-2007 Frederico Caldeira Knabben
 *
 * == BEGIN LICENSE ==
 *
 * Licensed under the terms of any of the following licenses at your
 * choice:
 *
 *  - GNU General Public License Version 2 or later (the "GPL")
 *    http://www.gnu.org/licenses/gpl.html
 *
 *  - GNU Lesser General Public License Version 2.1 or later (the "LGPL")
 *    http://www.gnu.org/licenses/lgpl.html
 *
 *  - Mozilla Public License Version 1.1 or later (the "MPL")
 *    http://www.mozilla.org/MPL/MPL-1.1.html
 *
 * == END LICENSE ==
 *
 * Arabic language file.
 */

var FCKLang =
{
// Language direction : "ltr" (left to right) or "rtl" (right to left).
Dir					: "rtl",

ToolbarCollapse		: "ضم شریط الأدوات",
ToolbarExpand		: "تمدد شریط الأدوات",

// Toolbar Items and Context Menu
Save				: "حفظ",
NewPage				: "صفحة جدیدة",
Preview				: "معاینة الصفحة",
Cut					: "قص",
Copy				: "نسخ",
Paste				: "لصق",
PasteText			: "لصق کنص بسیط",
PasteWord			: "لصق من وورد",
Print				: "طباعة",
SelectAll			: "تحدید الکل",
RemoveFormat		: "إزالة التنسیقات",
InsertLinkLbl		: "رابط",
InsertLink			: "إدراج/تحریر رابط",
RemoveLink			: "إزالة رابط",
Anchor				: "إدراج/تحریر إشارة مرجعیة",
InsertImageLbl		: "صورة",
InsertImage			: "إدراج/تحریر صورة",
InsertFlashLbl		: "فلاش",
InsertFlash			: "إدراج/تحریر فیلم فلاش",
InsertTableLbl		: "جدول",
InsertTable			: "إدراج/تحریر جدول",
InsertLineLbl		: "خط فاصل",
InsertLine			: "إدراج خط فاصل",
InsertSpecialCharLbl: "رموز",
InsertSpecialChar	: "إدراج  رموز..ِ",
InsertSmileyLbl		: "ابتسامات",
InsertSmiley		: "إدراج ابتسامات",
About				: "حول FCKeditor",
Bold				: "غامق",
Italic				: "مائل",
Underline			: "تسطیر",
StrikeThrough		: "یتوسطه خط",
Subscript			: "منخفض",
Superscript			: "مرتفع",
LeftJustify			: "محاذاة إلى الیسار",
CenterJustify		: "توسیط",
RightJustify		: "محاذاة إلى الیمین",
BlockJustify		: "ضبط",
DecreaseIndent		: "إنقاص المسافة البادئة",
IncreaseIndent		: "زیادة المسافة البادئة",
Undo				: "تراجع",
Redo				: "إعادة",
NumberedListLbl		: "تعداد رقمی",
NumberedList		: "إدراج/إلغاء تعداد رقمی",
BulletedListLbl		: "تعداد نقطی",
BulletedList		: "إدراج/إلغاء تعداد نقطی",
ShowTableBorders	: "معاینة حدود الجداول",
ShowDetails			: "معاینة التفاصیل",
Style				: "نمط",
FontFormat			: "تنسیق",
Font				: "خط",
FontSize			: "حجم الخط",
TextColor			: "لون النص",
BGColor				: "لون الخلفیة",
Source				: "شفرة المصدر",
Find				: "بحث",
Replace				: "إستبدال",
SpellCheck			: "تدقیق إملائی",
UniversalKeyboard	: "لوحة المفاتیح العالمیة",
PageBreakLbl		: "فصل الصفحة",
PageBreak			: "إدخال صفحة جدیدة",

Form			: "نموذج",
Checkbox		: "خانة إختیار",
RadioButton		: "زر خیار",
TextField		: "مربع نص",
Textarea		: "ناحیة نص",
HiddenField		: "إدراج حقل خفی",
Button			: "زر ضغط",
SelectionField	: "قائمة منسدلة",
ImageButton		: "زر صورة",

FitWindow		: "تکبیر حجم المحرر",

// Context Menu
EditLink			: "تحریر رابط",
CellCM				: "خلیة",
RowCM				: "صف",
ColumnCM			: "عمود",
InsertRow			: "إدراج صف",
DeleteRows			: "حذف صفوف",
InsertColumn		: "إدراج عمود",
DeleteColumns		: "حذف أعمدة",
InsertCell			: "إدراج خلیة",
DeleteCells			: "حذف خلایا",
MergeCells			: "دمج خلایا",
SplitCell			: "تقسیم خلیة",
TableDelete			: "حذف الجدول",
CellProperties		: "خصائص الخلیة",
TableProperties		: "خصائص الجدول",
ImageProperties		: "خصائص الصورة",
FlashProperties		: "خصائص فیلم الفلاش",

AnchorProp			: "خصائص الإشارة المرجعیة",
ButtonProp			: "خصائص زر الضغط",
CheckboxProp		: "خصائص خانة الإختیار",
HiddenFieldProp		: "خصائص الحقل الخفی",
RadioButtonProp		: "خصائص زر الخیار",
ImageButtonProp		: "خصائص زر الصورة",
TextFieldProp		: "خصائص مربع النص",
SelectionFieldProp	: "خصائص القائمة المنسدلة",
TextareaProp		: "خصائص ناحیة النص",
FormProp			: "خصائص النموذج",

FontFormats			: "عادی;منسّق;دوس;العنوان 1;العنوان  2;العنوان  3;العنوان  4;العنوان  5;العنوان  6",		//REVIEW : Check _getfontformat.html

// Alerts and Messages
ProcessingXHTML		: "إنتظر قلیلاً ریثما تتم   معالَجة‏ XHTML. لن یستغرق طویلاً...",
Done				: "تم",
PasteWordConfirm	: "یبدو أن النص المراد لصقه منسوخ من برنامج وورد. هل تود تنظیفه قبل الشروع فی عملیة اللصق؟",
NotCompatiblePaste	: "هذه المیزة تحتاج لمتصفح من النوعInternet Explorer إصدار 5.5 فما فوق. هل تود اللصق دون تنظیف الکود؟",
UnknownToolbarItem	: "عنصر شریط أدوات غیر معروف \"%1\"",
UnknownCommand		: "أمر غیر معروف \"%1\"",
NotImplemented		: "لم یتم دعم هذا الأمر",
UnknownToolbarSet	: "لم أتمکن من العثور على طقم الأدوات \"%1\" ",
NoActiveX			: "لتأمین متصفحک یجب أن تحدد بعض ممیزات المحرر. یتوجب علیک تمکین الخیار \"Run ActiveX controls and plug-ins\". قد تواجة أخطاء وتلاحظ ممیزات مفقودة",
BrowseServerBlocked : "لایمکن فتح مصدر المتصفح. فضلا یجب التأکد بأن جمیع موانع النوافذ المنبثقة معطلة",
DialogBlocked		: "لایمکن فتح نافذة الحوار . فضلا تأکد من أن  مانع النوافذ المنبثة معطل .",

// Dialogs
DlgBtnOK			: "موافق",
DlgBtnCancel		: "إلغاء الأمر",
DlgBtnClose			: "إغلاق",
DlgBtnBrowseServer	: "تصفح الخادم",
DlgAdvancedTag		: "متقدم",
DlgOpOther			: "<أخرى>",
DlgInfoTab			: "معلومات",
DlgAlertUrl			: "الرجاء کتابة عنوان الإنترنت",

// General Dialogs Labels
DlgGenNotSet		: "<بدون تحدید>",
DlgGenId			: "الرقم",
DlgGenLangDir		: "إتجاه النص",
DlgGenLangDirLtr	: "الیسار للیمین (LTR)",
DlgGenLangDirRtl	: "الیمین للیسار (RTL)",
DlgGenLangCode		: "رمز اللغة",
DlgGenAccessKey		: "مفاتیح الإختصار",
DlgGenName			: "الاسم",
DlgGenTabIndex		: "الترتیب",
DlgGenLongDescr		: "عنوان الوصف المفصّل",
DlgGenClass			: "فئات التنسیق",
DlgGenTitle			: "تلمیح الشاشة",
DlgGenContType		: "نوع التلمیح",
DlgGenLinkCharset	: "ترمیز المادة المطلوبة",
DlgGenStyle			: "نمط",

// Image Dialog
DlgImgTitle			: "خصائص الصورة",
DlgImgInfoTab		: "معلومات الصورة",
DlgImgBtnUpload		: "أرسلها للخادم",
DlgImgURL			: "موقع الصورة",
DlgImgUpload		: "رفع",
DlgImgAlt			: "الوصف",
DlgImgWidth			: "العرض",
DlgImgHeight		: "الإرتفاع",
DlgImgLockRatio		: "تناسق الحجم",
DlgBtnResetSize		: "إستعادة الحجم الأصلی",
DlgImgBorder		: "سمک الحدود",
DlgImgHSpace		: "تباعد أفقی",
DlgImgVSpace		: "تباعد عمودی",
DlgImgAlign			: "محاذاة",
DlgImgAlignLeft		: "یسار",
DlgImgAlignAbsBottom: "أسفل النص",
DlgImgAlignAbsMiddle: "وسط السطر",
DlgImgAlignBaseline	: "على السطر",
DlgImgAlignBottom	: "أسفل",
DlgImgAlignMiddle	: "وسط",
DlgImgAlignRight	: "یمین",
DlgImgAlignTextTop	: "أعلى النص",
DlgImgAlignTop		: "أعلى",
DlgImgPreview		: "معاینة",
DlgImgAlertUrl		: "فضلاً أکتب الموقع الذی توجد علیه هذه الصورة.",
DlgImgLinkTab		: "الرابط",

// Flash Dialog
DlgFlashTitle		: "خصائص فیلم الفلاش",
DlgFlashChkPlay		: "تشغیل تلقائی",
DlgFlashChkLoop		: "تکرار",
DlgFlashChkMenu		: "تمکین قائمة فیلم الفلاش",
DlgFlashScale		: "الحجم",
DlgFlashScaleAll	: "إظهار الکل",
DlgFlashScaleNoBorder	: "بلا حدود",
DlgFlashScaleFit	: "ضبط تام",

// Link Dialog
DlgLnkWindowTitle	: "إرتباط تشعبی",
DlgLnkInfoTab		: "معلومات الرابط",
DlgLnkTargetTab		: "الهدف",

DlgLnkType			: "نوع الربط",
DlgLnkTypeURL		: "العنوان",
DlgLnkTypeAnchor	: "مکان فی هذا المستند",
DlgLnkTypeEMail		: "برید إلکترونی",
DlgLnkProto			: "البروتوکول",
DlgLnkProtoOther	: "<أخرى>",
DlgLnkURL			: "الموقع",
DlgLnkAnchorSel		: "اختر علامة مرجعیة",
DlgLnkAnchorByName	: "حسب اسم العلامة",
DlgLnkAnchorById	: "حسب تعریف العنصر",
DlgLnkNoAnchors		: "<لا یوجد علامات مرجعیة فی هذا المستند>",		//REVIEW : Change < and > with ( and )
DlgLnkEMail			: "عنوان برید إلکترونی",
DlgLnkEMailSubject	: "موضوع الرسالة",
DlgLnkEMailBody		: "محتوى الرسالة",
DlgLnkUpload		: "رفع",
DlgLnkBtnUpload		: "أرسلها للخادم",

DlgLnkTarget		: "الهدف",
DlgLnkTargetFrame	: "<إطار>",
DlgLnkTargetPopup	: "<نافذة منبثقة>",
DlgLnkTargetBlank	: "إطار جدید (_blank)",
DlgLnkTargetParent	: "الإطار الأصل (_parent)",
DlgLnkTargetSelf	: "نفس الإطار (_self)",
DlgLnkTargetTop		: "صفحة کاملة (_top)",
DlgLnkTargetFrameName	: "اسم الإطار الهدف",
DlgLnkPopWinName	: "تسمیة النافذة المنبثقة",
DlgLnkPopWinFeat	: "خصائص النافذة المنبثقة",
DlgLnkPopResize		: "قابلة للتحجیم",
DlgLnkPopLocation	: "شریط العنوان",
DlgLnkPopMenu		: "القوائم الرئیسیة",
DlgLnkPopScroll		: "أشرطة التمریر",
DlgLnkPopStatus		: "شریط الحالة السفلی",
DlgLnkPopToolbar	: "شریط الأدوات",
DlgLnkPopFullScrn	: "ملئ الشاشة (IE)",
DlgLnkPopDependent	: "تابع (Netscape)",
DlgLnkPopWidth		: "العرض",
DlgLnkPopHeight		: "الإرتفاع",
DlgLnkPopLeft		: "التمرکز للیسار",
DlgLnkPopTop		: "التمرکز للأعلى",

DlnLnkMsgNoUrl		: "فضلاً أدخل عنوان الموقع الذی یشیر إلیه الرابط",
DlnLnkMsgNoEMail	: "فضلاً أدخل عنوان البرید الإلکترونی",
DlnLnkMsgNoAnchor	: "فضلاً حدد العلامة المرجعیة المرغوبة",
DlnLnkMsgInvPopName	: "اسم النافذة المنبثقة یجب أن یبدأ بحرف أبجدی دون مسافات",

// Color Dialog
DlgColorTitle		: "اختر لوناً",
DlgColorBtnClear	: "مسح",
DlgColorHighlight	: "تحدید",
DlgColorSelected	: "إختیار",

// Smiley Dialog
DlgSmileyTitle		: "إدراج إبتسامات ",

// Special Character Dialog
DlgSpecialCharTitle	: "إدراج رمز",

// Table Dialog
DlgTableTitle		: "إدراج جدول",
DlgTableRows		: "صفوف",
DlgTableColumns		: "أعمدة",
DlgTableBorder		: "سمک الحدود",
DlgTableAlign		: "المحاذاة",
DlgTableAlignNotSet	: "<بدون تحدید>",
DlgTableAlignLeft	: "یسار",
DlgTableAlignCenter	: "وسط",
DlgTableAlignRight	: "یمین",
DlgTableWidth		: "العرض",
DlgTableWidthPx		: "بکسل",
DlgTableWidthPc		: "بالمئة",
DlgTableHeight		: "الإرتفاع",
DlgTableCellSpace	: "تباعد الخلایا",
DlgTableCellPad		: "المسافة البادئة",
DlgTableCaption		: "الوصف",
DlgTableSummary		: "الخلاصة",

// Table Cell Dialog
DlgCellTitle		: "خصائص الخلیة",
DlgCellWidth		: "العرض",
DlgCellWidthPx		: "بکسل",
DlgCellWidthPc		: "بالمئة",
DlgCellHeight		: "الإرتفاع",
DlgCellWordWrap		: "التفاف النص",
DlgCellWordWrapNotSet	: "<بدون تحدید>",
DlgCellWordWrapYes	: "نعم",
DlgCellWordWrapNo	: "لا",
DlgCellHorAlign		: "المحاذاة الأفقیة",
DlgCellHorAlignNotSet	: "<بدون تحدید>",
DlgCellHorAlignLeft	: "یسار",
DlgCellHorAlignCenter	: "وسط",
DlgCellHorAlignRight: "یمین",
DlgCellVerAlign		: "المحاذاة العمودیة",
DlgCellVerAlignNotSet	: "<بدون تحدید>",
DlgCellVerAlignTop	: "أعلى",
DlgCellVerAlignMiddle	: "وسط",
DlgCellVerAlignBottom	: "أسفل",
DlgCellVerAlignBaseline	: "على السطر",
DlgCellRowSpan		: "إمتداد الصفوف",
DlgCellCollSpan		: "إمتداد الأعمدة",
DlgCellBackColor	: "لون الخلفیة",
DlgCellBorderColor	: "لون الحدود",
DlgCellBtnSelect	: "حدّد...",

// Find Dialog
DlgFindTitle		: "بحث",
DlgFindFindBtn		: "ابحث",
DlgFindNotFoundMsg	: "لم یتم العثور على النص المحدد.",

// Replace Dialog
DlgReplaceTitle			: "إستبدال",
DlgReplaceFindLbl		: "البحث عن:",
DlgReplaceReplaceLbl	: "إستبدال بـ:",
DlgReplaceCaseChk		: "مطابقة حالة الأحرف",
DlgReplaceReplaceBtn	: "إستبدال",
DlgReplaceReplAllBtn	: "إستبدال الکل",
DlgReplaceWordChk		: "الکلمة بالکامل فقط",

// Paste Operations / Dialog
PasteErrorCut	: "الإعدادات الأمنیة للمتصفح الذی تستخدمه تمنع القص التلقائی. فضلاً إستخدم لوحة المفاتیح لفعل ذلک (Ctrl+X).",
PasteErrorCopy	: "الإعدادات الأمنیة للمتصفح الذی تستخدمه تمنع النسخ التلقائی. فضلاً إستخدم لوحة المفاتیح لفعل ذلک (Ctrl+C).",

PasteAsText		: "لصق کنص بسیط",
PasteFromWord	: "لصق من وورد",

DlgPasteMsg2	: "الصق داخل الصندوق بإستخدام زرّی (<STRONG>Ctrl+V</STRONG>) فی لوحة المفاتیح، ثم اضغط زر  <STRONG>موافق</STRONG>.",
DlgPasteSec		: "Because of your browser security settings, the editor is not able to access your clipboard data directly. You are required to paste it again in this window.",	//MISSING
DlgPasteIgnoreFont		: "تجاهل تعریفات أسماء الخطوط",
DlgPasteRemoveStyles	: "إزالة تعریفات الأنماط",
DlgPasteCleanBox		: "نظّف محتوى الصندوق",

// Color Picker
ColorAutomatic	: "تلقائی",
ColorMoreColors	: "ألوان إضافیة...",

// Document Properties
DocProps		: "خصائص الصفحة",

// Anchor Dialog
DlgAnchorTitle		: "خصائص إشارة مرجعیة",
DlgAnchorName		: "اسم الإشارة المرجعیة",
DlgAnchorErrorName	: "الرجاء کتابة اسم الإشارة المرجعیة",

// Speller Pages Dialog
DlgSpellNotInDic		: "لیست فی القاموس",
DlgSpellChangeTo		: "التغییر إلى",
DlgSpellBtnIgnore		: "تجاهل",
DlgSpellBtnIgnoreAll	: "تجاهل الکل",
DlgSpellBtnReplace		: "تغییر",
DlgSpellBtnReplaceAll	: "تغییر الکل",
DlgSpellBtnUndo			: "تراجع",
DlgSpellNoSuggestions	: "- لا توجد إقتراحات -",
DlgSpellProgress		: "جاری التدقیق إملائیاً",
DlgSpellNoMispell		: "تم إکمال التدقیق الإملائی: لم یتم العثور على أی أخطاء إملائیة",
DlgSpellNoChanges		: "تم إکمال التدقیق الإملائی: لم یتم تغییر أی کلمة",
DlgSpellOneChange		: "تم إکمال التدقیق الإملائی: تم تغییر کلمة واحدة فقط",
DlgSpellManyChanges		: "تم إکمال التدقیق الإملائی: تم تغییر %1 کلمات\کلمة",

IeSpellDownload			: "المدقق الإملائی (الإنجلیزی) غیر مثبّت. هل تود تحمیله الآن؟",

// Button Dialog
DlgButtonText		: "القیمة/التسمیة",
DlgButtonType		: "نوع الزر",
DlgButtonTypeBtn	: "زر",
DlgButtonTypeSbm	: "إرسال",
DlgButtonTypeRst	: "إعادة تعیین",

// Checkbox and Radio Button Dialogs
DlgCheckboxName		: "الاسم",
DlgCheckboxValue	: "القیمة",
DlgCheckboxSelected	: "محدد",

// Form Dialog
DlgFormName		: "الاسم",
DlgFormAction	: "اسم الملف",
DlgFormMethod	: "الأسلوب",

// Select Field Dialog
DlgSelectName		: "الاسم",
DlgSelectValue		: "القیمة",
DlgSelectSize		: "الحجم",
DlgSelectLines		: "الأسطر",
DlgSelectChkMulti	: "السماح بتحدیدات متعددة",
DlgSelectOpAvail	: "الخیارات المتاحة",
DlgSelectOpText		: "النص",
DlgSelectOpValue	: "القیمة",
DlgSelectBtnAdd		: "إضافة",
DlgSelectBtnModify	: "تعدیل",
DlgSelectBtnUp		: "تحریک لأعلى",
DlgSelectBtnDown	: "تحریک لأسفل",
DlgSelectBtnSetValue : "إجعلها محددة",
DlgSelectBtnDelete	: "إزالة",

// Textarea Dialog
DlgTextareaName	: "الاسم",
DlgTextareaCols	: "الأعمدة",
DlgTextareaRows	: "الصفوف",

// Text Field Dialog
DlgTextName			: "الاسم",
DlgTextValue		: "القیمة",
DlgTextCharWidth	: "العرض بالأحرف",
DlgTextMaxChars		: "عدد الحروف الأقصى",
DlgTextType			: "نوع المحتوى",
DlgTextTypeText		: "نص",
DlgTextTypePass		: "کلمة مرور",

// Hidden Field Dialog
DlgHiddenName	: "الاسم",
DlgHiddenValue	: "القیمة",

// Bulleted List Dialog
BulletedListProp	: "خصائص التعداد النقطی",
NumberedListProp	: "خصائص التعداد الرقمی",
DlgLstStart			: "البدء عند",
DlgLstType			: "النوع",
DlgLstTypeCircle	: "دائرة",
DlgLstTypeDisc		: "قرص",
DlgLstTypeSquare	: "مربع",
DlgLstTypeNumbers	: "أرقام (1، 2، 3)َ",
DlgLstTypeLCase		: "حروف صغیرة (a, b, c)َ",
DlgLstTypeUCase		: "حروف کبیرة (A, B, C)َ",
DlgLstTypeSRoman	: "ترقیم رومانی صغیر (i, ii, iii)َ",
DlgLstTypeLRoman	: "ترقیم رومانی کبیر (I, II, III)َ",

// Document Properties Dialog
DlgDocGeneralTab	: "عام",
DlgDocBackTab		: "الخلفیة",
DlgDocColorsTab		: "الألوان والهوامش",
DlgDocMetaTab		: "المعرّفات الرأسیة",

DlgDocPageTitle		: "عنوان الصفحة",
DlgDocLangDir		: "إتجاه اللغة",
DlgDocLangDirLTR	: "الیسار للیمین (LTR)",
DlgDocLangDirRTL	: "الیمین للیسار (RTL)",
DlgDocLangCode		: "رمز اللغة",
DlgDocCharSet		: "ترمیز الحروف",
DlgDocCharSetCE		: "أوروبا الوسطى",
DlgDocCharSetCT		: "الصینیة التقلیدیة (Big5)",
DlgDocCharSetCR		: "السیریلیة",
DlgDocCharSetGR		: "الیونانیة",
DlgDocCharSetJP		: "الیابانیة",
DlgDocCharSetKR		: "الکوریة",
DlgDocCharSetTR		: "الترکیة",
DlgDocCharSetUN		: "Unicode (UTF-8)",
DlgDocCharSetWE		: "أوروبا الغربیة",
DlgDocCharSetOther	: "ترمیز آخر",

DlgDocDocType		: "ترویسة نوع  الصفحة",
DlgDocDocTypeOther	: "ترویسة نوع  صفحة أخرى",
DlgDocIncXHTML		: "تضمین   إعلانات‏ لغة XHTMLَ",
DlgDocBgColor		: "لون الخلفیة",
DlgDocBgImage		: "رابط الصورة الخلفیة",
DlgDocBgNoScroll	: "جعلها علامة مائیة",
DlgDocCText			: "النص",
DlgDocCLink			: "الروابط",
DlgDocCVisited		: "المزارة",
DlgDocCActive		: "النشطة",
DlgDocMargins		: "هوامش الصفحة",
DlgDocMaTop			: "علوی",
DlgDocMaLeft		: "أیسر",
DlgDocMaRight		: "أیمن",
DlgDocMaBottom		: "سفلی",
DlgDocMeIndex		: "الکلمات الأساسیة (مفصولة بفواصل)َ",
DlgDocMeDescr		: "وصف الصفحة",
DlgDocMeAuthor		: "الکاتب",
DlgDocMeCopy		: "المالک",
DlgDocPreview		: "معاینة",

// Templates Dialog
Templates			: "القوالب",
DlgTemplatesTitle	: "قوالب المحتوى",
DlgTemplatesSelMsg	: "اختر القالب الذی تود وضعه فی المحرر <br>(سیتم فقدان المحتوى الحالی):",
DlgTemplatesLoading	: "جاری تحمیل قائمة القوالب، الرجاء الإنتظار...",
DlgTemplatesNoTpl	: "(لم یتم تعریف أی قالب)",
DlgTemplatesReplace	: "استبدال المحتوى",

// About Dialog
DlgAboutAboutTab	: "نبذة",
DlgAboutBrowserInfoTab	: "معلومات متصفحک",
DlgAboutLicenseTab	: "الترخیص",
DlgAboutVersion		: "الإصدار",
DlgAboutInfo		: "لمزید من المعلومات تفضل بزیارة"
};