$(function(){
	var qty = 0
    $(".qty-container span").html(`x${qty}`)

    $("#minus-btn").on('click', function(){
		if (qty > 0)
			qty -= 1;
		$(".qty-container span").html(`x${qty}`);
		$("#cantidad").val(qty);
    })

    $("#plus-btn").on('click', function(){
		if (qty < 99)
			qty += 1;
		$(".qty-container span").html(`x${qty}`);
		$("#cantidad").val(qty);
    })
    
	//INGREDIENTS SELECTION
	var ingredients = {
		cover: {
			sphere_sprinkles: {img:"/assets/img/make-stuff/donut-layers/covers/sphere_sprinkles.png"},
			sprinkles: {img:"/assets/img/make-stuff/donut-layers/covers/large_sprinkles.png"},
			choco: {img:"/assets/img/make-stuff/donut-layers/covers/choco_sprinkles.png"}
		},
		glazed: {
			white: {img:"/assets/img/make-stuff/donut-layers/glazed/white_glaze.png"},
			pink: {img:"/assets/img/make-stuff/donut-layers/glazed/pink_glaze.png"},
			choco: {img:"/assets/img/make-stuff/donut-layers/glazed/choco_glaze.png"}
		},
	}

	var selectedIngredients = {}

	$(".cover-option").on('click', function(){
		let id = $(this).attr("id")
		switch(id){
			case "cover-option-1":
				$(".cover-donut").css("background-image", `url(${ingredients.cover.sphere_sprinkles.img})`);
				$("#cover-option-1rb").prop("checked", "true");
				Object.assign(selectedIngredients, { cover: "sphere_sprinkles" });
				break;
			case "cover-option-2":
				$(".cover-donut").css("background-image", `url(${ingredients.cover.sprinkles.img})`);
				$("#cover-option-2rb").prop("checked", "true");
				Object.assign(selectedIngredients, { cover: "sprinkles" });
				break;
			case "cover-option-3":
				$(".cover-donut").css("background-image", `url(${ingredients.cover.choco.img})`);
				$("#cover-option-3rb").prop("checked", "true");
				Object.assign(selectedIngredients, { cover: "choco" });
				break;
		}

		$(".active-cover").removeClass("active-cover")
		$(this).addClass("active-cover")
	})

	$(".glazed-option").on('click', function(){
		let id = $(this).attr("id")
		switch(id){
			case "glass-option-1":
				$(".glazed-donut").css("background-image", `url(${ingredients.glazed.white.img})`);
				$("#glass-option-1rb").prop("checked", "true");
				Object.assign(selectedIngredients, { glazed: "white" });
				break;
			case "glass-option-2":
				$(".glazed-donut").css("background-image", `url(${ingredients.glazed.pink.img})`);
				$("#glass-option-2rb").prop("checked", "true");
				Object.assign(selectedIngredients, { glazed: "pink" });
				break;
			case "glass-option-3":
				$(".glazed-donut").css("background-image", `url(${ingredients.glazed.choco.img})`);
				$("#glass-option-3rb").prop("checked", "true");
				Object.assign(selectedIngredients, { glazed: "choco" });
				break;
		}

		$(".active-glazed").removeClass("active-glazed")
		$(this).addClass("active-glazed")
	})

	$(".filling-option").on('click', function(){
		let id = $(this).attr("id")
		switch(id){
			case "fill-option-1":
				$("#fill-option-1rb").prop("checked", "true");
				Object.assign(selectedIngredients, { filling: "cajeta" });
				break;
			case "fill-option-2":
				$("#fill-option-2rb").prop("checked", "true");
				Object.assign(selectedIngredients, { filling: "nutella" });
				break;
			case "fill-option-3":
				$("#fill-option-3rb").prop("checked", "true");
				Object.assign(selectedIngredients, { filling: "strawberry" });
				break;

		}

		$(".active-filling").removeClass("active-filling")
		$(this).addClass("active-filling")
	})

	$(".clear-ingredients-btn").on('click', function(){
		selectedIngredients = {}
		qty = 0

		$(".qty-container span").html(`x${qty}`)
		$(".qty-preview span").html(`x${qty}`)
		$(".glazed-donut").css("background-image", "")
		$(".cover-donut").css("background-image", "")
		$(".glazed-preview").css("background-image", "")
		$(".cover-preview").css("background-image", "")
		$(".active-cover").removeClass("active-cover")
		$(".active-glazed").removeClass("active-glazed")
		$(".active-filling").removeClass("active-filling")
	})
	
    $("#ready-btn").on('click', function(){
		console.log(ingredients)
		console.log(selectedIngredients)
    	let y = $(document).scrollTop()

    	$("#confirm-window").css("top", y).fadeIn()
    	$("#confirm-window").css("display","flex")
		$("body").css("overflow","hidden")

		$(".qty-preview span").html(`x${qty}`)
		
		$(".glazed-preview").css("background-image", `url(${ingredients.glazed[selectedIngredients.glazed].img})`)
		$(".cover-preview").css("background-image", `url(${ingredients.cover[selectedIngredients.cover].img})`)
    })

    $(".close-btn").on('click', function(){
    	$("#confirm-window").fadeOut()
    	$("body").css("overflow","auto")
	})
	
	$(".custom-confirm-btn").on('click', function(){
		$("#payment-window").fadeIn()
	})

	$("#cancel-payment").on('click', function(){
		$("#payment-window").fadeOut()
	})

	$("input[name='payment-method-checker']").on('change', function(){
		let method = $("input[name='payment-method-checker']:checked", '#payment-method-form').val()
		switch(method){
			case "credit":
				$(".credit-inputs-container").css("display","block")
				break;
			case "cash":
				$(".credit-inputs-container").css("display","none")
				break;
		}
	})
})