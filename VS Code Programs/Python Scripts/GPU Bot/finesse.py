import time
from selenium import webdriver

bbEmail = 'cromeo5112@gmail.com'
bbPass = 'King9235112'
sc = '917'

rtx3080fe = 'https://www.bestbuy.com/site/nvidia-geforce-rtx-3080-10gb-gddr6x-pci-express-4-0-graphics-card-titanium-and-black/6429440.p?skuId=6429440'
appleAirpods = 'https://www.bestbuy.com/site/apple-airpods-pro-white/5706659.p?skuId=5706659'
bbCart = 'https://www.bestbuy.com/cart'
bbCheckOut = 'https://www.bestbuy.com/checkout/r/fast-track'
bbSignIn = 'https://www.bestbuy.com/identity/global/signin'

browser = webdriver.Chrome('../chromedriver')
browser.get(bbSignIn)
email = browser.find_element_by_id('fld-e')
password = browser.find_element_by_id('fld-p1')
keepSignIn = browser.find_elements_by_class_name('c-checkbox-custom-input')
signIn = browser.find_element_by_class_name('cia-form__controls ')
email.send_keys(bbEmail)
password.send_keys(bbPass)
keepSignIn[0].click()
signIn.click()
time.sleep(2)
browser.get(rtx3080fe)

buy = False
while not buy:

    try:
        addToCart = browser.find_element_by_class_name("btn-disabled")
        print("Button not ready")
        time.sleep(1)
        browser.refresh()
    except:

        addToCart = browser.find_element_by_class_name("btn-primary")
        addToCart.click()
        buy = True
        print("Added to Cart")

browser.get(bbCheckOut)
sec = browser.find_element_by_id('credit-card-cvv')
sec.send_keys(sc)
updates = browser.find_element_by_id('text-updates')
updates.click()
placeOrder = browser.find_element_by_class_name("button--place-order-fast-track")
placeOrder.click()