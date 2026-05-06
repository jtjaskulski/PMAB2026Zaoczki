import React, { useEffect, useState } from 'react';
import {
  View,
  Text,
  StyleSheet,
  TouchableOpacity,
  TextInput,
  FlatList,
  ScrollView,
  Alert,
} from 'react-native';

type Props = {
  moduleName: string;
  onBack: () => void;
};

type Field = {
  key: string;
  label: string;
};

type CrudItem = {
  id: number;
  [key: string]: string | number | boolean | null;
};

const API_URL = 'http://10.0.2.2:5000/api';

const apiByModule: Record<string, string> = {
  Rowery: 'Rowery',
  Klienci: 'Klienci',
  Wypożyczenia: 'Wypozyczenia',
  Serwis: 'Serwisy',
  Płatności: 'Platnosci',
  'Typy rowerów': 'TypyRowerow',
  Kategorie: 'Kategorie',
  'Metody Płatności': 'MetodyPlatnosci',
};

const fieldsByModule: Record<string, Field[]> = {
  Rowery: [
    { key: 'nazwa', label: 'Nazwa roweru' },
    { key: 'typ', label: 'Typ roweru' },
    { key: 'cena', label: 'Cena za godzinę' },
    { key: 'status', label: 'Status' },
  ],
  Klienci: [
    { key: 'imie', label: 'Imię' },
    { key: 'nazwisko', label: 'Nazwisko' },
    { key: 'telefon', label: 'Telefon' },
  ],
  Wypożyczenia: [
    { key: 'klient', label: 'Klient' },
    { key: 'rower', label: 'Rower' },
    { key: 'dataWypozyczenia', label: 'Data wypożyczenia' },
    { key: 'dataZwrotu', label: 'Data zwrotu' },
    { key: 'status', label: 'Status' },
  ],
  Serwis: [
    { key: 'rower', label: 'Rower' },
    { key: 'opisUsterki', label: 'Opis usterki' },
    { key: 'status', label: 'Status' },
  ],
  Płatności: [
    { key: 'klient', label: 'Klient' },
    { key: 'kwota', label: 'Kwota' },
    { key: 'metoda', label: 'Metoda płatności' },
    { key: 'status', label: 'Status' },
  ],
  'Typy rowerów': [
    { key: 'nazwa', label: 'Nazwa typu' },
    { key: 'opis', label: 'Opis' },
  ],
  Kategorie: [
    { key: 'nazwa', label: 'Nazwa kategorii' },
    { key: 'opis', label: 'Opis kategorii' },
  ],
  'Metody Płatności': [
    { key: 'nazwa', label: 'Nazwa metody' },
    { key: 'opis', label: 'Opis' },
    { key: 'aktywna', label: 'Aktywna' },
  ],
};

export default function CrudScreen({ moduleName, onBack }: Props) {
  const fields = fieldsByModule[moduleName] || [];
  const endpoint = apiByModule[moduleName];

  const emptyForm = fields.reduce((acc, field) => {
    acc[field.key] = '';
    return acc;
  }, {} as Record<string, string>);

  const [items, setItems] = useState<CrudItem[]>([]);
  const [form, setForm] = useState<Record<string, string>>(emptyForm);
  const [editingId, setEditingId] = useState<number | null>(null);

  const loadItems = async () => {
    try {
      const response = await fetch(`${API_URL}/${endpoint}`);
      const data = await response.json();
      setItems(data);
    } catch {
      Alert.alert('Błąd', 'Nie udało się pobrać danych z API.');
    }
  };

  useEffect(() => {
    loadItems();
  }, [moduleName]);

  const updateField = (key: string, value: string) => {
    setForm({ ...form, [key]: value });
  };

  const prepareBody = () => {
    const body: Record<string, string | number | boolean | null> = {};

    fields.forEach((field) => {
      const value = form[field.key];

      if (field.key === 'cena' || field.key === 'kwota') {
        body[field.key] = Number(value);
      } else if (field.key === 'aktywna') {
        body[field.key] = value.toLowerCase() === 'true' || value === '1' || value.toLowerCase() === 'tak';
      } else if (field.key === 'dataZwrotu' && value.trim() === '') {
        body[field.key] = null;
      } else {
        body[field.key] = value;
      }
    });

    return body;
  };

  const saveItem = async () => {
    const hasValue = Object.values(form).some((value) => value.trim() !== '');
    if (!hasValue) return;

    try {
      const method = editingId !== null ? 'PUT' : 'POST';
      const url =
        editingId !== null
          ? `${API_URL}/${endpoint}/${editingId}`
          : `${API_URL}/${endpoint}`;

      const body = prepareBody();

      if (editingId !== null) {
        body.id = editingId;
      }

      const response = await fetch(url, {
        method,
        headers: {
          'Content-Type': 'application/json',
        },
        body: JSON.stringify(body),
      });

      if (!response.ok) {
        Alert.alert('Błąd', 'Nie udało się zapisać danych.');
        return;
      }

      setEditingId(null);
      setForm(emptyForm);
      loadItems();
    } catch {
      Alert.alert('Błąd', 'Brak połączenia z API.');
    }
  };

  const editItem = (item: CrudItem) => {
    const newForm: Record<string, string> = {};

    fields.forEach((field) => {
      newForm[field.key] = String(item[field.key] ?? '');
    });

    setForm(newForm);
    setEditingId(Number(item.id));
  };

  const deleteItem = async (id: number) => {
    try {
      const response = await fetch(`${API_URL}/${endpoint}/${id}`, {
        method: 'DELETE',
      });

      if (!response.ok) {
        Alert.alert('Błąd', 'Nie udało się usunąć elementu.');
        return;
      }

      loadItems();
    } catch {
      Alert.alert('Błąd', 'Brak połączenia z API.');
    }
  };

  const cancelEdit = () => {
    setEditingId(null);
    setForm(emptyForm);
  };

  return (
    <View style={styles.container}>
      <TouchableOpacity onPress={onBack}>
        <Text style={styles.back}>← Wróć</Text>
      </TouchableOpacity>

      <Text style={styles.title}>{moduleName}</Text>

      <ScrollView showsVerticalScrollIndicator={false}>
        <View style={styles.formCard}>
          <Text style={styles.formTitle}>
            {editingId ? 'Edytuj element' : 'Dodaj nowy element'}
          </Text>

          {fields.map((field) => (
            <View key={field.key} style={styles.inputGroup}>
              <Text style={styles.label}>{field.label}</Text>
              <TextInput
                value={form[field.key]}
                onChangeText={(value) => updateField(field.key, value)}
                placeholder={field.label}
                placeholderTextColor="#64748B"
                style={styles.input}
              />
            </View>
          ))}

          <TouchableOpacity style={styles.saveButton} onPress={saveItem}>
            <Text style={styles.saveButtonText}>
              {editingId ? 'Zapisz zmiany' : 'Dodaj'}
            </Text>
          </TouchableOpacity>

          {editingId && (
            <TouchableOpacity style={styles.cancelButton} onPress={cancelEdit}>
              <Text style={styles.cancelText}>Anuluj edycję</Text>
            </TouchableOpacity>
          )}
        </View>

        <Text style={styles.listTitle}>Lista</Text>

        <FlatList
          data={items}
          keyExtractor={(item) => item.id.toString()}
          scrollEnabled={false}
          contentContainerStyle={styles.list}
          ListEmptyComponent={
            <Text style={styles.emptyText}>Brak elementów do wyświetlenia</Text>
          }
          renderItem={({ item }) => (
            <View style={styles.itemCard}>
              {fields.map((field, index) => (
                <Text
                  key={field.key}
                  style={index === 0 ? styles.itemMainText : styles.itemText}
                >
                  {field.label}: {String(item[field.key] ?? '-')}
                </Text>
              ))}

              <View style={styles.actions}>
                <TouchableOpacity onPress={() => editItem(item)}>
                  <Text style={styles.edit}>Edytuj</Text>
                </TouchableOpacity>

                <TouchableOpacity onPress={() => deleteItem(Number(item.id))}>
                  <Text style={styles.delete}>Usuń</Text>
                </TouchableOpacity>
              </View>
            </View>
          )}
        />
      </ScrollView>
    </View>
  );
}

const styles = StyleSheet.create({
  container: { flex: 1, backgroundColor: '#0F172A', padding: 20 },
  back: { color: '#E5A24A', fontSize: 16, fontWeight: '700', marginBottom: 14 },
  title: { color: '#F9FAFB', fontSize: 30, fontWeight: 'bold', marginBottom: 18 },
  formCard: {
    backgroundColor: '#1E293B',
    borderRadius: 18,
    padding: 18,
    borderWidth: 1,
    borderColor: '#334155',
    marginBottom: 22,
  },
  formTitle: { color: '#F9FAFB', fontSize: 18, fontWeight: '800', marginBottom: 14 },
  inputGroup: { marginBottom: 12 },
  label: { color: '#CBD5E1', fontSize: 14, fontWeight: '600', marginBottom: 6 },
  input: {
    backgroundColor: '#0F172A',
    borderWidth: 1,
    borderColor: '#334155',
    borderRadius: 14,
    padding: 14,
    color: '#F9FAFB',
    fontSize: 15,
  },
  saveButton: {
    backgroundColor: '#E5A24A',
    padding: 16,
    borderRadius: 16,
    alignItems: 'center',
    marginTop: 8,
  },
  saveButtonText: { color: '#0F172A', fontWeight: '800', fontSize: 16 },
  cancelButton: { marginTop: 12, alignItems: 'center' },
  cancelText: { color: '#94A3B8', fontWeight: '600' },
  listTitle: { color: '#F9FAFB', fontSize: 20, fontWeight: '800', marginBottom: 12 },
  list: { gap: 12, paddingBottom: 30 },
  emptyText: { color: '#94A3B8', textAlign: 'center', marginTop: 20 },
  itemCard: {
    backgroundColor: '#1E293B',
    borderRadius: 16,
    padding: 16,
    borderWidth: 1,
    borderColor: '#334155',
  },
  itemMainText: { color: '#F9FAFB', fontSize: 16, fontWeight: '800', marginBottom: 6 },
  itemText: { color: '#CBD5E1', fontSize: 14, marginBottom: 4 },
  actions: { flexDirection: 'row', gap: 20, marginTop: 12 },
  edit: { color: '#E5A24A', fontWeight: '700' },
  delete: { color: '#F87171', fontWeight: '700' },
});