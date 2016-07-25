cart_browser_ie = true;
cart_browser_iemac = false;
cart_browser_ie4 = false;
cart_browser_safari = false;
cart_browser_konqueror = false;
cart_browser_transitions = true;
cart_browser_opera = false;
cart_browser_mozilla = false;
cart_browser_shadows = true;
cart_browser_slides = true;
cart_browser_overlays = true;
cart_browser_hideselects = true;
cart_browser_addeventhandlers = true;
cart_browser_contextmenus = true;
cart_browser_noncustomcontextmenus = true;
cart_browser_expandonclick = true;
cart_browser_recyclegroups = true;

function ComponentArt_Init_NBN1_MN() {
if (!(window.cart_menu_kernel_loaded && window.cart_menu_support_loaded))
	{setTimeout('ComponentArt_Init_NBN1_MN()', 500); return; }

window.NBN1_MN = new ComponentArt_Menu('NBN1_MN', ComponentArt_Storage_NBN1_MN);
NBN1_MN.CascadeCollapse = true;
NBN1_MN.ClientSideOnItemSelect = null;
NBN1_MN.ClientSideOnItemMouseOut = null;
NBN1_MN.ClientSideOnItemMouseOver = null;
NBN1_MN.CssClass = null;
NBN1_MN.CollapseDelay = 0;
NBN1_MN.CollapseDuration = 200;
NBN1_MN.CollapseSlide = 0;
NBN1_MN.CollapseTransition = 0;
NBN1_MN.CollapseTransitionCustomFilter = null;
NBN1_MN.ContextControlId = null;
NBN1_MN.ContextData = null;
NBN1_MN.ContextMenu = 0;
NBN1_MN.ExpandDelay = 0;
NBN1_MN.ExpandDuration = 200;
NBN1_MN.ExpandOnClick = false;
NBN1_MN.ExpandSlide = 0;
NBN1_MN.ExpandTransition = 0;
NBN1_MN.ExpandTransitionCustomFilter = null;
NBN1_MN.Height = null;
NBN1_MN.HideSelectElements = cart_browser_hideselects && true;
NBN1_MN.HighlightExpandedPath = true;
NBN1_MN.Orientation = 0;
NBN1_MN.OverlayWindowedElements = cart_browser_overlays && true;
NBN1_MN.PlaceHolderId = 'NBN1_MN_div';
NBN1_MN.ShadowColor = '#8D8F95';
NBN1_MN.ShadowEnabled = true;
NBN1_MN.ShadowOffset = 2;
NBN1_MN.TopGroupItemSpacing = null;
NBN1_MN.Width = '100%';

RenderMenu(NBN1_MN,'NBN1_MN_div');
//ComponentArt_Menu_InitKeyboard(NBN1_MN);
window.NBN1_MN_loaded = true;
}
