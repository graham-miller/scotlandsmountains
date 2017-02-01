export function toFriendlyUrlName(raw) {
    return raw.replace(/\s/gmi, "_").replace(/[^a-z0-9_]/gmi, "");
}