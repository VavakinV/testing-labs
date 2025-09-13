function getElementByXPath(path) 
{
  return document.evaluate(path, document, null, XPathResult.FIRST_ORDERED_NODE_TYPE, null).singleNodeValue;
}

function delay(ms) 
{
	return new Promise(resolve => setTimeout(resolve, ms));
}

function click_add(n)
{
	for (let i = 0; i < n; i++) 
	{
		getElementByXPath("//button[@onclick='addElement()']").click();
	}
}

function click_remove(n)
{
	getElementByXPath("//button[@class='added-manually']["+n+"]").click();
}

async function main()
{
	click_add(4);
    await delay(3000);
	click_remove(3);
}

main();