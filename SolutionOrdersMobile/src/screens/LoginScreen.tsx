import React, { useState } from 'react';
import {
  View,
  Text,
  StyleSheet,
  Image,
  TextInput,
  TouchableOpacity,
} from 'react-native';

type Props = {
  onLogin: () => void;
};

export default function LoginScreen({ onLogin }: Props) {
  const [email, setEmail] = useState('admin@bike.pl');
  const [password, setPassword] = useState('admin123');

  return (
    <View style={styles.container}>
      <Image source={require('../../assets/logo3.png')} style={styles.logo} />

      <Text style={styles.title}>Bike-Rental</Text>
      <Text style={styles.subtitle}>Logowanie do panelu pracownika</Text>

      <View style={styles.form}>
        <Text style={styles.label}>Adres e-mail</Text>
        <TextInput
          style={styles.input}
          placeholder="Wpisz e-mail"
          placeholderTextColor="#64748B"
          value={email}
          onChangeText={setEmail}
        />

        <Text style={styles.label}>Hasło</Text>
        <TextInput
          style={styles.input}
          placeholder="Wpisz hasło"
          placeholderTextColor="#64748B"
          value={password}
          onChangeText={setPassword}
          secureTextEntry
        />

        <TouchableOpacity style={styles.loginButton} onPress={onLogin}>
          <Text style={styles.loginButtonText}>Zaloguj się</Text>
        </TouchableOpacity>
      </View>

      <Text style={styles.hint}>Dane testowe: admin@bike.pl / admin123</Text>
    </View>
  );
}

const styles = StyleSheet.create({
  container: {
    flex: 1,
    backgroundColor: '#0F172A',
    paddingHorizontal: 24,
    justifyContent: 'center',
  },
  logo: {
    width: 150,
    height: 95,
    resizeMode: 'contain',
    alignSelf: 'center',
  },
  title: {
    color: '#E5A24A',
    fontSize: 30,
    fontWeight: 'bold',
    textAlign: 'center',
    marginTop: 8,
  },
  subtitle: {
    color: '#94A3B8',
    fontSize: 15,
    textAlign: 'center',
    marginTop: 6,
    marginBottom: 32,
  },
  form: {
    gap: 10,
  },
  label: {
    color: '#CBD5E1',
    fontSize: 14,
    fontWeight: '600',
    marginTop: 8,
  },
  input: {
    backgroundColor: '#1E293B',
    borderWidth: 1,
    borderColor: '#334155',
    borderRadius: 16,
    padding: 16,
    color: '#F9FAFB',
    fontSize: 15,
  },
  loginButton: {
    backgroundColor: '#E5A24A',
    padding: 18,
    borderRadius: 18,
    alignItems: 'center',
    marginTop: 20,
  },
  loginButtonText: {
    color: '#0F172A',
    fontWeight: 'bold',
    fontSize: 16,
  },
  hint: {
    color: '#64748B',
    textAlign: 'center',
    marginTop: 24,
    fontSize: 12,
  },
});