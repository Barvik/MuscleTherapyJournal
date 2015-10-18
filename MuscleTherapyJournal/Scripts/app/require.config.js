var require = {
	paths: {
		"bootstrap": "/Scripts/lib/bootstrap.min",
		"jquery": "/Scripts/lib/jquery-1.10.2",
		"knockout": "/Scripts/lib/knockout-3.2.0",
		"knockout-projections": "/Scripts/lib/knockout-projections",
		"signals": "/Scripts/lib/signals.min",
		"text": "/Scripts/lib/text",
		"router": "/Scripts/app/router"
	},
	shim: {
		"bootstrap": { deps: ["jquery"] }
	}
};